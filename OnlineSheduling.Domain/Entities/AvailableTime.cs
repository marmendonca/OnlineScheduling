using System;

namespace OnlineScheduling.Domain.Entities
{
    public class AvailableTime : Entitiy<int>
    {
        public int? ProfessionalId { get; private set; }
        public Professional? Professional { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public int Interval { get; private set; }
        public bool Active { get; private set; }
        
        private AvailableTime() { }

        public void SetActive(bool active) => Active = active;
    }
}