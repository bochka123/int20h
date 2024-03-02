using System.ComponentModel.DataAnnotations.Schema;
using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class SessionAnswer : BaseEntity
    {
        public required Guid AnswerId { get; set; }
        public QuestionOption Answer { get; set; }
        public required Guid SessionId { get; set; }
        public TestSession Session { get; set; }
        public bool IsCorrect { get; set; }
    }
}
