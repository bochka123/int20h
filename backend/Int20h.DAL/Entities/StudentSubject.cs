using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class StudentSubject : BaseEntity
{
    public StudentInformation StudentInformation { get; set; }
    public Guid StudentId { get; set; }
    public Subject Subject { get; set; }
    public Guid SubjectId { get; set; }
    public ICollection<TestSession> TestSessions { get; set; }
    public double Mark { get; set; }
    public bool IsCompleted { get; set; }
    public ICollection<StudentLesson> AttendedLessons { get; set; }
    public int AttendencePercentage { get; set; }
}
