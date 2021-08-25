using OnlineScheduling.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule GetById(long id);

        Schedule IsExists(TimeSpan scheduleHour, DateTime scheduleDate);

        IEnumerable<Schedule> GetSchedulesByCustumer(string phone);
    }
}
