namespace Int20h.Common.Dtos.User
{
	public class UserDto
	{
		public string Email { get; set; }
		public string Phone { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string AvatarUrl { get; set; }
		public string AccessToken { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
