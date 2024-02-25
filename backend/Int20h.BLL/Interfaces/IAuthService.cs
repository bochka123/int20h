using Int20h.Common.Dtos.User;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IAuthService
{
	Task<Response<UserDto>> SignInAsync(SignInUserDto userDto);
	Task<Response<UserDto>> CreateAsync(SignUpUserDto userDto);
	Response<AccessTokenDto> GenerateAccessToken(string refreshToken);
	Response<string> GenerateRefreshToken(UserDto userDto);
}
