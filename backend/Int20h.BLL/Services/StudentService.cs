using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class StudentService : BaseService, IStudentService
{
	public StudentService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

	public async Task<Response<List<StudentDto>>> GetAllStudents()
	{
		var students = await _context.StudentInformations
			.Include(s => s.User)
			.ToListAsync();

		return new Response<List<StudentDto>>(_mapper.Map<List<StudentDto>>(students));
	}
}
