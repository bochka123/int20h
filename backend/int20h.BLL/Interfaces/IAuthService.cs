using int20h.Common.Dtos.User;
using int20h.Common.Response;

namespace int20h.BLL.Interfaces;

public interface IAuthService
{
	Task<Response<UserDto>> SignInAsync(SignInUserDto userDto);
	Task<Response<UserDto>> CreateAsync(SignUpUserDto userDto);
	Task<Response<AccessTokenDto>> GenerateAccessToken(string refreshToken);
	Task<Response<string>> GenerateRefreshToken(UserDto userDto);
}
