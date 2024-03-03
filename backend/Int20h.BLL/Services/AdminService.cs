using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.User;
using Int20h.Common.Enums;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class AdminService : BaseService, IAdminService
{
    private readonly UserManager<User> _userManager;
    public AdminService(UserManager<User> userManager, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _userManager = userManager;
    }

    public async Task<Response<UserDto>> CreateAdmin(SignUpUserDto userDto)
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

        await _userManager.AddToRoleAsync(user, Roles.Admin);

        var userResponse = _mapper.Map<UserDto>(user);

        return new Response<UserDto>(userResponse, "You have created admin succesfully");
    }
}
