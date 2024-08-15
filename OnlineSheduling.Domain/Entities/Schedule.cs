using System;

namespace OnlineScheduling.Domain.Entities
{
    public class Schedule : Entitiy<int>
    {
        public int ServiceId { get; private set; }
        public int CustomerId { get; private set; }
        public int ProfessionalId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public virtual Service Service { get; private set; }
        public virtual Customer Customer { get; private set; }
        public virtual Professional Professional { get; set; }
    }
}