namespace Int20h.Common.Request
{
    public class GetRequest
    {
        public Dictionary<string, object>? Filter { get; set; }
        public int? Skip { get; set; }
        public int? Take {  get; set; }
    }
}
