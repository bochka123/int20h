using Int20h.Common.Dtos.User;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IAdminService
{
    Task<Response<UserDto>> CreateAdmin(SignUpUserDto userDto);
}
