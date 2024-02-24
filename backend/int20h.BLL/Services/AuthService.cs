using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;

using int20h.BLL.Interfaces;
using int20h.BLL.Services.Abstract;
using int20h.Common.Dtos.User;
using int20h.Common.Helpers;
using int20h.Common.Response;
using int20h.DAL.Context;
using int20h.DAL.Entities;

namespace int20h.BLL.Services;

public class AuthService : BaseService, IAuthService
{
	private readonly JwtOptionsHelper _jwtOptionsHelper;

	public AuthService(ApplicationDbContext context, IMapper mapper, IOptions<JwtOptionsHelper> jwtOptionsHelper) : base(context, mapper)
	{
		_jwtOptionsHelper = jwtOptionsHelper.Value;
	}
	public async Task<Response<UserDto>> CreateAsync(SignUpUserDto userDto)
	{
		var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
		if (user != null)
		{
			return new Response<UserDto>
			{
				Message = $"User with email {userDto.Email} alreasy exists",
				Status = Status.Error
			};
		}

		user = _mapper.Map<User>(userDto);
		user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
		user.CreatedAt = DateTime.UtcNow;
		user.UpdatedAt = DateTime.UtcNow;

		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();

		var userResponse = _mapper.Map<UserDto>(user);
		userResponse.AccessToken = GenerateJwt(user);

		return new Response<UserDto>()
		{
			Value = userResponse,
			Message = "You have sign up succesfully",
			Status = Status.Success
		};
	}

	public async Task<Response<UserDto>> SignInAsync(SignInUserDto userDto)
	{
		var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
		if (user == null)
		{
			return new Response<UserDto>
			{
				Message = $"User with email {userDto.Email} was not found",
				Status = Status.Error
			};
		}

		if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
		{
			return new Response<UserDto>
			{
				Message = "Wrong password",
				Status = Status.Error
			};
		}

		var userResponse = _mapper.Map<UserDto>(user);
		userResponse.AccessToken = GenerateJwt(user);

		return new Response<UserDto>()
		{
			Value = userResponse,
			Message = "You have sign in succesfully",
			Status = Status.Success
		};
	}

	public Response<AccessTokenDto> GenerateAccessToken(string refreshToken)
	{
		var email = DecodeJwt(refreshToken);

		if(string.IsNullOrEmpty(email))
		{
			return new Response<AccessTokenDto>
			{
				Message = "Wrong refresh token",
				Status = Status.Error
			};
		}

		var user = _context.Users.FirstOrDefault(u => u.Email == email);
		if (user == null)
		{
			return new Response<AccessTokenDto>
			{
				Message = $"User with email {email} was not found",
				Status = Status.Error
			};
		}

		var accessToken = new AccessTokenDto()
		{
			AccessToken = GenerateJwt(user)
		};

		return new Response<AccessTokenDto>()
		{
			Value = accessToken,
			Status = Status.Success
		};
	}

	public Response<string> GenerateRefreshToken(UserDto userDto)
	{
		var user = _mapper.Map<User>(userDto);

		return new Response<string>()
		{
			Value = GenerateJwt(user),
			Status = Status.Success
		};
	}

	private string GenerateJwt(User user)
	{
		var claims = new List<Claim>
			{
				new(ClaimTypes.Email, user.Email)
			};

		var tokenHandler = new JwtSecurityTokenHandler();

		var securityTokenDescription = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Issuer = _jwtOptionsHelper.Issuer,
			Audience = _jwtOptionsHelper.Audience,
			Expires = DateTime.UtcNow.AddMinutes(_jwtOptionsHelper.TokenExpiration),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptionsHelper.Key)), SecurityAlgorithms.HmacSha256)
		};

		var jwt = tokenHandler.CreateToken(securityTokenDescription);

		return tokenHandler.WriteToken(jwt);
	}

	private string DecodeJwt(string jwtToken)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

		if (token != null)
		{
			return token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email || claim.Type == "email")?.Value;
		}
		else
		{
			return string.Empty;
		}
	}
}
