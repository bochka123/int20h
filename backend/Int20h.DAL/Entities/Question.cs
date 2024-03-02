using System.ComponentModel;
using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class Question : BaseEntity
{
    [DisplayName("Question Title")]
    public required string Title { get; set; }
    [DisplayName("Question Text")]
    public required string Text { get; set; }
    public Test Test { get; set; }
    public Guid TestId { get; set; }
    public ICollection<QuestionOption> QuestionOptions { get; set; }
    public double Cost { get; set; }
}
