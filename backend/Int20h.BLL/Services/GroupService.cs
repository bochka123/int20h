using System.Collections.Generic;
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

        if (user is null)
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

    public async Task<Response<IEnumerable<GroupDto>>> GetUserGroups(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user is null)
        {
            return new Response<IEnumerable<GroupDto>>(Status.Error, "No such user!");
        }

        var student = await _context.StudentInformations.Include(student => student.Group).FirstOrDefaultAsync(s => s.UserId == user.Id);

        if (student is not null) 
        {
            var group = await _context.Groups.Where(group => group.Id == student.Group.Id).FirstOrDefaultAsync();

            var groupDto = _mapper.Map<GroupDto>(group);

            var groups = new List<GroupDto>
            {
                groupDto
            };

            return new Response<IEnumerable<GroupDto>>(groups);
        }

        var teacher = await _context.TeacherInformations.FirstOrDefaultAsync(s => s.UserId == user.Id);

        if (teacher is not null)
        {
            var groups = await _context.Groups.Where(group => group.MentorId == teacher.Id).ToListAsync();

            var groupDtos = _mapper.Map<IEnumerable<Group> ,IEnumerable <GroupDto>>(groups).ToList();

            return new Response<IEnumerable<GroupDto>>(groupDtos);
        }

        return new Response<IEnumerable<GroupDto>>(new List<GroupDto>());
    }
}
