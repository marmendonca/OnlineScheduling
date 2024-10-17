using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.AvailableTimes.GetByProfessional
{
    public sealed class GetAvailableTimesByProfessionalQueryResponse
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Interval { get; set; }
        public bool Active { get; set; }
        
        public static explicit operator GetAvailableTimesByProfessionalQueryResponse(AvailableTime availableTime)
        {
            return new GetAvailableTimesByProfessionalQueryResponse
            {
                Id = availableTime.Id,
                StartTime = availableTime.StartTime,
                EndTime = availableTime.EndTime,
                Interval = availableTime.Interval,
                Active = availableTime.Active
            };
        }
    }
}