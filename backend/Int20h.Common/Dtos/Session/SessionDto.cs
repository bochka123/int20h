namespace Int20h.Common.Dtos.Session
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid TestId { get; set; }
        public IEnumerable<SessionAnswerDto> Answers { get; set; }
        public double Mark { get; set; }
        public bool IsFinished { get; set; }
    }
}
