using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class Group: IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<StudentInformation> Students { get; set; }
        public TeacherInformation Mentor { get; set; }
    }
}
