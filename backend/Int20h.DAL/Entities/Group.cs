using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<StudentInformation> Students { get; set; }
        public TeacherInformation Mentor { get; set; }
        public Guid MentorId { get; set; }
        public int Year { get; set; }
    }
}
