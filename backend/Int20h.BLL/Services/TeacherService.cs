using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services;

public class TeacherService : BaseService, ITeacherService
{
    public TeacherService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

	public async Task<Response<List<TeacherDto>>> GetAllTeachers(bool notVerified)
	{
		var students = await _context.TeacherInformations
			.Where(s => notVerified ? !s.IsVerified : true)
			.Include(s => s.User)
			.ToListAsync();

		return new Response<List<TeacherDto>>(_mapper.Map<List<TeacherDto>>(students));
	}

	public async Task<Response<TeacherDto>> GetTeacherById(Guid id)
	{
		var student = await _context.TeacherInformations
			.Include(s => s.User)
			.FirstOrDefaultAsync(s => s.Id == id);

		return new Response<TeacherDto>(_mapper.Map<TeacherDto>(student));
	}
}
