using Int20h.Common.Dtos.Group;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IGroupService
{
    Task<Response<GroupDto>> CreateGroup(CreateGroupDto createGroupDto);
    Task<Response<List<GroupDto>>> GetAllGroups();
}
