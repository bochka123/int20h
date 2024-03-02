using Int20h.Common.Enums;

namespace Int20h.Common.Dtos.User
{
	public class SignUpUserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
		public string GroupName { get; set; }
	}
}
