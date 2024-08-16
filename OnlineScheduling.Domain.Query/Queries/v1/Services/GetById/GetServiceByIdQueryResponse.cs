namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById
{
    public sealed class GetServiceByIdQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TimeSpan? CompletionTime { get; set; }
        public bool Active { get; set; }
    }
}