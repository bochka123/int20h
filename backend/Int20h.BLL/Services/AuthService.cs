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
using Int20h.Common.Enums;
using Role = Int20h.DAL.Entities.Role;

namespace Int20h.BLL.Services;

public class AuthService : BaseService, IAuthService
{
	private readonly UserManager<User> _userManager;
	private readonly RoleManager<Role> _roleManager;
	private readonly ITokenService _tokenService;

	public AuthService(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, 
		RoleManager<Role> roleManager, ITokenService tokenService) : base(context, mapper)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_tokenService = tokenService;
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

		if (userDto.Role == Common.Enums.Role.Student)
		{
			var group = _context.Groups.FirstOrDefault(x => x.Name == userDto.GroupName);
            if (group == null)
            {
				return new Response<UserDto>(Status.Error, "No group with such name");
            }
            var studentInformation = new StudentInformation()
			{
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				UserId = user.Id,
				GroupId = group.Id
			};
		}
        else
        {
			var teacherInformation = new TeacherInformation()
			{
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				UserId = user.Id
			};
        }
		await _context.SaveChangesAsync();

        var userResponse = _mapper.Map<UserDto>(user);
		userResponse.AccessToken = await _tokenService.GenerateJwtAsync(user);

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
		userResponse.AccessToken = await _tokenService.GenerateJwtAsync(user);

		return new Response<UserDto>()
		{
			Value = userResponse,
			Message = "You have sign in succesfully",
			Status = Status.Success
		};
	}
}
