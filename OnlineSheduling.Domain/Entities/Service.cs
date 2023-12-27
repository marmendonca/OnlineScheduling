using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities;

public class Service : Entitiy<int>
{
    public string Name { get; private set; }
    public ICollection<Schedule> Schedules { get; private set; }
}