using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.Find
{
    public class FindServiceQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TimeSpan? CompletionTime { get; set; }
        public bool Active { get; set; }

        public static explicit operator FindServiceQueryResponse(Service service)
        {
            return new FindServiceQueryResponse()
            {
                Id = service.Id,
                CreatedAt = service.CreatedAt,
                Name = service.Name,
                Value = service.Value,
                CompletionTime = service.CompletionTime,
                Active = service.Active,
            };
        }
    }
}