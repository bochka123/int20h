using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.File;
using Int20h.Common.Dtos.User;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Microsoft.AspNetCore.Http;

namespace Int20h.BLL.Services;

public class UserService : BaseService, IUserService
{
    private readonly IAzureBlobStorageService _azureBlobStorageService;

    public UserService(ApplicationDbContext context, IMapper mapper, IAzureBlobStorageService azureBlobStorageService) : base(context, mapper)
    {
        _azureBlobStorageService = azureBlobStorageService;
    }

    public Task<Response<UserDto>> DeletePhoto(FileDto fileDto, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<UserDto>> UpdatePhoto(IFormFile file, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<UserDto>> UpdateUser(EditUserDto userDto)
    {
        throw new NotImplementedException();
    }
}
