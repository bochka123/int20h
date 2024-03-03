using Int20h.Common.Dtos.User;

namespace Int20h.Common.Dtos.Student;

public class TeacherDto
{
	public Guid Id { get; set; }
	public UserDto? User { get; set; }
	public bool IsVerified { get; set; }
}
