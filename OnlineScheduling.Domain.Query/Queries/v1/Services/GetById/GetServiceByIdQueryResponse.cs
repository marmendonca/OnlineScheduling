using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById;

public sealed class GetServiceByIdQueryResponse
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public TimeSpan? CompletionTime { get; set; }
    public bool Active { get; set; }

    public static explicit operator GetServiceByIdQueryResponse(Service service)
    {
        return new GetServiceByIdQueryResponse()
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