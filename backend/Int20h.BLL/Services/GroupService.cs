using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Group;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class GroupService : BaseService, IGroupService
{
    private readonly UserManager<User> _userManager;
    private readonly IPagingService _pagingService;
    public GroupService(IPagingService pagingService, UserManager<User> userManager, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _userManager = userManager;
        _pagingService = pagingService;
    }

    public async Task<Response<GroupDto>> CreateGroup(CreateGroupDto createGroupDto)
    {
        var user = await _userManager.FindByEmailAsync(createGroupDto.MentorEmail);

        if(user is null)
        {
            return new Response<GroupDto>(Status.Error, "Teacher with this email does not exist!");
        }

        var mentor = await _context.TeacherInformations.FirstOrDefaultAsync(teacher => teacher.UserId == user.Id);

        if (mentor is null)
        {
            return new Response<GroupDto>(Status.Error, "This user is not a teacher!");
        }

        var group = _mapper.Map<Group>(createGroupDto);
        group.MentorId = mentor.Id;

        await _context.Groups.AddAsync(group);

        await _context.SaveChangesAsync();

        var groupResponse = _mapper.Map<GroupDto>(group);

        return new Response<GroupDto>(groupResponse, "Group was created successfuly!");
    }

    public async Task<PageResponse<IEnumerable<GroupDto>>> GetAllGroups(GetRequest getRequest)
    {
        return await _pagingService.ApplyPaging<Group, GroupDto>(_context.Groups, getRequest);
    }
}
