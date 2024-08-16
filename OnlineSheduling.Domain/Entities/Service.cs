using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities;

public class Service : Entitiy<int>
{
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public TimeSpan? CompletionTime { get; private set; }
    public bool Active { get; private set; }
    public ICollection<Schedule> Schedules { get; private set; }
    public ICollection<ProfessionalService> Professionals { get; private set; }
    
    private Service() { }
}