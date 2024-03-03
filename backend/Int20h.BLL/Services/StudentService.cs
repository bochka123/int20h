using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Group;
using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class StudentService : BaseService, IStudentService
{
    private readonly UserManager<User> _userManager;
    public StudentService(UserManager<User> userManager, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
	{
		_userManager = userManager;
	}

	public async Task<Response<List<StudentDto>>> GetAllStudents(bool notVerified)
	{
		var students = await _context.StudentInformations
			.Where(s => notVerified ? !s.IsVerified : true)
			.Include(s => s.User)
			.ToListAsync();

		return new Response<List<StudentDto>>(_mapper.Map<List<StudentDto>>(students));
	}

	public async Task<Response<StudentDto>> GetStudentById(Guid id)
	{
		var student = await _context.StudentInformations
			.Include(s => s.User)
			.FirstOrDefaultAsync(s => s.Id == id);

		return new Response<StudentDto>(_mapper.Map<StudentDto>(student));
	}

    public async Task<Response<StudentDto>> PinStudentDto(PinStudentDto pinStudentDto)
    {
        var user = await _userManager.FindByEmailAsync(pinStudentDto.Email);

        if (user is null)
        {
            return new Response<StudentDto>(Status.Error, "No such user!");
        }

        var student = await _context.StudentInformations.Include(student => student.StudentSubjects).FirstOrDefaultAsync(s => s.UserId == user.Id);

        if (student is null)
        {
            return new Response<StudentDto>(Status.Error, "No student with this email!");
        }

		student.StudentSubjects.Add(new StudentSubject()
		{
			SubjectId = pinStudentDto.SubjectId
		});

		await _context.SaveChangesAsync();

		var studentDto = _mapper.Map<StudentDto>(student);

        return new Response<StudentDto>(studentDto, "Subject was added successfuly!");
    }
}
