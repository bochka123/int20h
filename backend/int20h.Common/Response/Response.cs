namespace Int20h.Common.Response;

public class Response<T>
{
    public T? Value { get; set; }
    public string Message { get; set; } = string.Empty;
    public Status Status { get; set; }
}
