using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.AvailableDates.Find;

public sealed class FindAvailableDatesQueryResponse
{
    public int Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int Interval { get; set; }
    public int? ProfessionalId { get; set; }
    public bool Active { get; set; }
        
    public static explicit operator FindAvailableDatesQueryResponse(AvailableDate availableDate)
    {
        return new FindAvailableDatesQueryResponse
        {
            Id = availableDate.Id,
            StartAt = availableDate.StartAt,
            EndAt = availableDate.EndAt,
            Interval = availableDate.Interval,
            Active = availableDate.Active,
            ProfessionalId = availableDate.ProfessionalId
        };
    }
}