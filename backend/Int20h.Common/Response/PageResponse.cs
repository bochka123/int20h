namespace Int20h.Common.Response
{
    public class PageResponse<T>: Response<T> where T : class
    {
        public PageResponse(T data): base(data)
        {
            Value = data;
        }
        public int? Page { get; set; }
        public int Count { get; set; }
        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}
