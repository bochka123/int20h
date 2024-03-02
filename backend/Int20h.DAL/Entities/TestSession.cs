using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class TestSession: BaseEntity
{
    public StudentInformation Student { get; set; }
    public Guid StudentId { get; set; }
    public Test Test { get; set; }
    public Guid TestId { get; set; }
    public ICollection<SessionAnswer> Answers { get; set; }
    public double Mark { get; set; }
}
