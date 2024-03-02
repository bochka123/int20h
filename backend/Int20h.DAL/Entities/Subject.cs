using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; }
    public ICollection<StudentSubject> StudentSubjects { get; set; }
    public ICollection<TeacherInformation> Teachers { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Test> Tests { get; set; }
}
