using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Group;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Int20h.BLL.Services;

public class GroupService : BaseService, IGroupService
{
    private readonly UserManager<User> _userManager;
    public GroupService(UserManager<User> userManager, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _userManager = userManager;
    }

    public async Task<Response<GroupDto>> CreateGroup(CreateGroupDto createGroupDto)
    {
        var mentor = await _userManager.FindByEmailAsync(createGroupDto.MentorEmail);

        if(mentor is null)
        {
            return new Response<GroupDto>(Status.Error, "Teacher with this email does not exist");
        }

        var group = _mapper.Map<Group>(createGroupDto);
        group.MentorId = mentor.Id;

        await _context.Groups.AddAsync(group);

        await _context.SaveChangesAsync();

        var groupResponse = _mapper.Map<GroupDto>(group);

        return new Response<GroupDto>(groupResponse, "Group was created successfuly!");
    }
}
