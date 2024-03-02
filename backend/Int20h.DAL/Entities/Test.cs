using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class Test : BaseEntity
{
    public ICollection<Question> Questions { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Subject Subject { get; set; }
    public Guid SubjectId { get; set; }
    public int NumberOfAttempts { get; set; }
    public double Cost { get; set; }

}
