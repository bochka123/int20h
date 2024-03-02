using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class Lesson : BaseEntity
{
    public Subject Subject { get; set; }
    public Guid SubjectId { get; set; }
    public string Topic { get; set; }
}
