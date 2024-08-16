using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities;

public class Professional : Entitiy<int>
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public DateTime BirthDate { get; set; }
    public virtual ICollection<ProfessionalService> Services { get; private set; }
    public ICollection<Schedule> Schedules { get; private set; }
        
    private Professional() { }
}