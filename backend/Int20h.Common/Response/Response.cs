namespace Int20h.Common.Response
{
    public class Response
    {
        public Response(string message, IEnumerable<string> errors) : this(Status.Error, message)
        {
            Errors = errors;
        }
        public Response(Status status, string? message = null)
        {
            Status = status;
            Message = message ?? status.ToString();
        }
        public Response() : this(Status.Success)
        { }
        public Status Status { get; init; }
        public string Message { get; init; }
        public IEnumerable<string>? Errors { get; init; }
    }
}
