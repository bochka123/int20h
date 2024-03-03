using Int20h.Common.Dtos.Group;
using Int20h.Common.Request;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IGroupService
{
    Task<Response<GroupDto>> CreateGroup(CreateGroupDto createGroupDto);
    Task<PageResponse<IEnumerable<GroupDto>>> GetAllGroups(GetRequest getRequest);
    Task<Response<IEnumerable<GroupDto>>> GetUserGroups(string userEmail);
}
