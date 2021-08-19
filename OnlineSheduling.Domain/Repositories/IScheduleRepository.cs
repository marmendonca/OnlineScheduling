using OnlineScheduling.Domain.Entities;
using System;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule GetById(long id);

        Schedule IsExists(TimeSpan scheduleHour, DateTime scheduleDate);
    }
}
