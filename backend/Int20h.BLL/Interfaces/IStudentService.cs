using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface IStudentService
{
	Task<Response<List<StudentDto>>> GetAllStudents(bool notVerified);
	Task<Response<StudentDto>> GetStudentById(Guid id);
	Task<Response<StudentDto>> PinStudentDto(PinStudentDto pinStudentDto);
}
