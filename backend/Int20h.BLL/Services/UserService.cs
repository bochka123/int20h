using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.File;
using Int20h.Common.Dtos.User;
using Int20h.Common.Enums;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class UserService : BaseService, IUserService
{
	private readonly IAzureBlobStorageService _azureBlobStorageService;
	private readonly UserManager<User> _userManager;

	public UserService(ApplicationDbContext context, IMapper mapper, IAzureBlobStorageService azureBlobStorageService, UserManager<User> userManager) : base(context, mapper)
	{
		_azureBlobStorageService = azureBlobStorageService;
		_userManager = userManager;
	}

	public async Task<Response<UserDto>> DeletePhoto(FileDto fileDto, Guid userId)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new ArgumentNullException("User was not found");

		await _azureBlobStorageService.DeleteFromBlob(fileDto);

		user.AvatarUrl = string.Empty;

		_context.Users.Update(user);

		await _context.SaveChangesAsync();

		var userResponse = _mapper.Map<UserDto>(user);

		return new Response<UserDto>(userResponse, "You have deleted user photo succesfully");
	}

	public async Task<Response> DeleteUser(Guid userId)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new ArgumentNullException("User was not found");

		await _userManager.DeleteAsync(user);

		return new Response();
	}

	public async Task<Response<UserDto>> UpdatePhoto(IFormFile file, Guid userId)
	{
		var fileDto = new NewFileDto()
		{
			Stream = file.OpenReadStream(),
			FileName = file.FileName
		};

		var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new ArgumentNullException("User was not found");

		if (!string.IsNullOrEmpty(user.AvatarUrl))
		{
			var oldFile = new FileDto()
			{
				Url = user.AvatarUrl
			};

			await _azureBlobStorageService.DeleteFromBlob(oldFile);
		}

		var addedFile = await _azureBlobStorageService.AddFileToBlobStorage(fileDto);

		user.AvatarUrl = addedFile.Url!;

		await _userManager.UpdateAsync(user);

		var userResponse = _mapper.Map<UserDto>(user);

		return new Response<UserDto>(userResponse, "You have updated user photo succesfully");
	}

	public async Task<Response<UserDto>> UpdateUser(EditUserDto userDto)
	{
		var user = await _userManager.FindByEmailAsync(userDto.Email);

		if (user is null)
		{
			return new Response<UserDto>(Status.Error, $"User with email {userDto.Email} not found");
		}

		user.FirstName = userDto.FirstName;
		user.LastName = userDto.LastName;
		user.Email = userDto.Email;
		user.PhoneNumber = userDto.Phone;
		user.UpdatedAt = DateTime.UtcNow;

		await _userManager.UpdateAsync(user);

		var userResponse = _mapper.Map<UserDto>(user);

		return new Response<UserDto>(userResponse, "You have updated user succesfully");
	}


	public async Task<Response<UserDto>> ConfirmUserRole(ConfirmUserRoleDto userDto)
	{
		var user = await _userManager.FindByEmailAsync(userDto.Email);

		if (user is null)
		{
			return new Response<UserDto>(Status.Error, $"User with email {userDto.Email} not found");
		}

		var student = await _context.StudentInformations.FirstOrDefaultAsync(s => s.Id == user.Id);

		if (student != null)
		{
			await _userManager.AddToRoleAsync(user, Roles.Student);

			student.IsVerified = true;
			_context.StudentInformations.Update(student);

			await _context.SaveChangesAsync();
			return new Response<UserDto>(_mapper.Map<UserDto>(user), "You have confirmed role succesfully");
		}

		var teacher = await _context.TeacherInformations.FirstOrDefaultAsync(t => t.UserId == user.Id);

		if (teacher != null)
		{
			await _userManager.AddToRoleAsync(user, Roles.Teacher);
			_context.TeacherInformations.Update(teacher);

			await _context.SaveChangesAsync();
			return new Response<UserDto>(_mapper.Map<UserDto>(user), "You have confirmed role succesfully");
		}

		return new Response<UserDto>(Status.Error, "No such user");
	}
}
