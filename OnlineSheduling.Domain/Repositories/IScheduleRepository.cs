using OnlineScheduling.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule GetById(long id);

        Schedule IsExists(DateTime scheduleDate);

        IEnumerable<Schedule> GetSchedulesByPhone(string phone);
    }
}
