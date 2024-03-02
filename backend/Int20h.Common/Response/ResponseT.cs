namespace Int20h.Common.Response;

public class Response<T> : Response where T : class
{
    public Response(T data, string? message = null) : base(Status.Success, message)
    {
        Value = data;
    }

    public Response(string message, IEnumerable<string> errors) : base(message, errors)
    {
    }

    public Response(Status status, string? message = null) : base(status, message)
    {
    }
    public Response() : base()
    {
    }

    public T? Value { get; init; }
}
