using Int20h.Common.Dtos.File;
using Int20h.Common.Dtos.User;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Http;

namespace Int20h.BLL.Interfaces;

public interface IUserService
{
    Task<Response<UserDto>> UpdateUser(EditUserDto userDto);
    Task<Response<bool>> DeleteUser(Guid userId);
    Task<Response<UserDto>> UpdatePhoto(IFormFile file, Guid userId);
    Task<Response<UserDto>> DeletePhoto(FileDto fileDto, Guid userId);
}
