using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;

using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.User;
using Int20h.Common.Helpers;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Int20h.BLL.Services;

public class AuthService : BaseService, IAuthService
{
	private readonly JwtOptionsHelper _jwtOptionsHelper;
	private readonly UserManager<User> _userManager;
	private readonly RoleManager<Role> _roleManager;

	public AuthService(ApplicationDbContext context, IMapper mapper, IOptions<JwtOptionsHelper> jwtOptionsHelper,
		UserManager<User> userManager, RoleManager<Role> roleManager) : base(context, mapper)
	{
		_jwtOptionsHelper = jwtOptionsHelper.Value;
		_userManager = userManager;
		_roleManager = roleManager;
	}
	public async Task<Response<UserDto>> SignUpAsync(SignUpUserDto userDto)
	{
		var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
		if (user != null)
		{
			return new Response<UserDto>(Status.Error, $"User with email {userDto.Email} alreasy exists");
		}

		user = _mapper.Map<User>(userDto);
		user.CreatedAt = DateTime.Now;
		user.UpdatedAt = DateTime.Now;
		user.UserName = userDto.Email;
        var result = await _userManager.CreateAsync(user, userDto.Password);
        if (!result.Succeeded)
        {
            return new Response<UserDto>("Error while creating user.", result.Errors.Select(u => u.Description));
        }

		var userResponse = _mapper.Map<UserDto>(user);
		userResponse.AccessToken = await GenerateJwtAsync(user);

		return new Response<UserDto>(userResponse, "You have sign up succesfully");
	}

	public async Task<Response<UserDto>> SignInAsync(SignInUserDto userDto)
	{
		var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
		if (user == null)
		{
            return new Response<UserDto>(Status.Error, $"User with email {userDto.Email} was not found");
        }

        if (!await _userManager.CheckPasswordAsync(user, userDto.Password))
        {
            return new(Status.Error, "Incorrect password.");
        }

		var userResponse = _mapper.Map<UserDto>(user);
		userResponse.AccessToken = await GenerateJwtAsync(user);

		return new Response<UserDto>()
		{
			Value = userResponse,
			Message = "You have sign in succesfully",
			Status = Status.Success
		};
	}

	public async Task<Response<AccessTokenDto>> GenerateAccessTokenAsync(string refreshToken)
	{
		var email = DecodeJwt(refreshToken);

		if (string.IsNullOrEmpty(email))
		{
			return new Response<AccessTokenDto>(Status.Error, "Wrong refresh token");
		}

		var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		if (user == null)
		{
			return new Response<AccessTokenDto>(Status.Error, $"User with email {email} was not found");
		}

		var accessToken = new AccessTokenDto()
		{
			AccessToken = await GenerateJwtAsync(user)
		};

		return new Response<AccessTokenDto>()
		{
			Value = accessToken,
			Status = Status.Success
		};
	}

	private string DecodeJwt(string jwtToken)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

		if (token != null)
		{
			return token.Claims.First(claim => claim.Type == ClaimTypes.Email || claim.Type == "email").Value;
		}
		else
		{
			return string.Empty;
		}
	}

	private async Task<string> GenerateJwtAsync(User user)
	{
		var userRoles = await _userManager.GetRolesAsync(user);
		var tokenHandler = new JwtSecurityTokenHandler();
		var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Email, user.Email!)
			};
		var key = Encoding.UTF8.GetBytes(_jwtOptionsHelper.Key);
		userRoles.ToList().ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Issuer = _jwtOptionsHelper.Issuer,
			Audience = _jwtOptionsHelper.Audience,
			Expires = DateTime.UtcNow.AddMinutes(30),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}

    public Response<string> GenerateRefreshToken(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email!)
            };
        var key = Encoding.UTF8.GetBytes(_jwtOptionsHelper.RefreshTokenKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtOptionsHelper.Issuer,
            Audience = _jwtOptionsHelper.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Response<string>(tokenHandler.WriteToken(token));
    }
}
