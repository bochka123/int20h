using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface ITeacherService
{
	Task<Response<List<TeacherDto>>> GetAllTeachers(bool notVerified);
	Task<Response<TeacherDto>> GetTeacherById(Guid id);
}
