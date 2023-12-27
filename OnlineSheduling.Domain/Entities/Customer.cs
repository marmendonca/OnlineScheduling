using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities
{
    public class Customer : Entitiy<int>
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public ICollection<Schedule> Schedules { get; private set; }
    }
}