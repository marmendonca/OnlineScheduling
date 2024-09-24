using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.Find;

public class FindScheduleQueryResponse
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }

    public static explicit operator FindScheduleQueryResponse(Schedule schedule)
    {
        return new()
        {
            Id = schedule.Id,
            Date = schedule.ScheduleAt,
            CustomerName = schedule.Customer?.Name,
            CustomerPhone = schedule.Customer?.Phone,
            CustomerEmail = schedule.Customer?.Email,
            ServiceName = schedule.Service?.Name
        };
    }
}