using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities
{
    public class Professional : Entitiy<int>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<ProfessionalService> Services { get; set; }
        public ICollection<Schedule> Schedules { get; private set; }
    }
}