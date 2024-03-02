using Int20h.Common.Dtos.User;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IAuthService
{
	Task<Response<UserDto>> SignInAsync(SignInUserDto userDto);
    Task<Response<UserDto>> SignUpAsync(SignUpUserDto userDto);
}
