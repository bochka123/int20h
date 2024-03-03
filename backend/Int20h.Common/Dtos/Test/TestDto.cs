namespace Int20h.Common.Dtos.Test
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfAttempts { get; set; } = 1;
        public Guid SubjectId { get; set; }
        public double Cost { get; set; }
    }
}
