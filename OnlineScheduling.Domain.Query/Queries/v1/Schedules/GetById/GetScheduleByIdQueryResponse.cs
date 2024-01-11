namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQueryResponse
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
}