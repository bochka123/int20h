using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class TeacherInformation : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
		public bool IsVerified { get; set; }
		public ICollection<Group> MentorGroups { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
