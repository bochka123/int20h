namespace Int20h.DAL.Entities;

public class StudentLesson
{
    public StudentInformation Student { get; set; }
    public Guid StudentId { get; set; }
    public Lesson Lesson { get; set; }
    public Guid LessonId { get; set; }
    public double Mark { get; set; }
    public bool IsAttended { get; set; }
}
