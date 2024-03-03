using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Subject;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class SubjectService : BaseService, ISubjectService
{
    private readonly UserManager<User> _userManager;
    private readonly IPagingService _pagingService;
    public SubjectService(IPagingService pagingService, UserManager<User> userManager, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _userManager = userManager;
        _pagingService = pagingService;
    }

    public async Task<Response<SubjectDto>> CreateSubject(CreateSubjectDto createSubjectDto)
    {
        var user = await _userManager.FindByEmailAsync(createSubjectDto.MainTeacherEmail);

        if (user is null)
        {
            return new Response<SubjectDto>(Status.Error, "Teacher with this email does not exist!");
        }

        var teacher = await _context.TeacherInformations.FirstOrDefaultAsync(teacher => teacher.UserId == user.Id);

        if (teacher is null)
        {
            return new Response<SubjectDto>(Status.Error, "This user is not a teacher!");
        }

        var subject = new Subject()
        {
            Name = createSubjectDto.Name,
            Teachers = new List<TeacherInformation>()
            {
                teacher
            }
        };

        await _context.Subjects.AddAsync(subject);

        await _context.SaveChangesAsync();

        var subjectResponse = _mapper.Map<SubjectDto>(subject);

        return new Response<SubjectDto>(subjectResponse, "Subject was created successfuly!");
    }

    public async Task<PageResponse<IEnumerable<SubjectDto>>> GetAllSubjects(GetRequest getRequest)
    {
        return await _pagingService.ApplyPaging<Subject, SubjectDto>(_context.Subjects, getRequest);
    }
}
