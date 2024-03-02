using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities;

public class QuestionOption : BaseEntity
{
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
    public Question Question { get; set; }
    public Guid QuestionId { get; set; }
}
