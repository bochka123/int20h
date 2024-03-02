using Int20h.Common.Dtos.User;
using Int20h.Common.Response;
using Int20h.DAL.Entities;

namespace Int20h.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<Response<AccessTokenDto>> GenerateAccessTokenAsync(string refreshToken);
        Response<string> GenerateRefreshToken(UserDto userDto);
        Task<string> GenerateJwtAsync(User user);
    }
}
