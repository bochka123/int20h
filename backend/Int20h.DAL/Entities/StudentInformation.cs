using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class StudentInformation : BaseEntity
    {
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public bool IsVerified { get; set; }
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
