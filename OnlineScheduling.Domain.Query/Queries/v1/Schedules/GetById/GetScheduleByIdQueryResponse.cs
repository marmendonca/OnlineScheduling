using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQueryResponse
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
    public ScheduleStatus Status { get; set; }

    public static explicit operator GetScheduleByIdQueryResponse(Schedule schedule)
    {
        return new()
        {
            Id = schedule.Id,
            Date = schedule.ScheduleAt,
            Status = schedule.Status,
            CustomerName = schedule.Customer?.Name,
            CustomerPhone = schedule.Customer?.Phone,
            CustomerEmail = schedule.Customer?.Email,
            ServiceName = schedule.Service?.Name
        };
    }
}