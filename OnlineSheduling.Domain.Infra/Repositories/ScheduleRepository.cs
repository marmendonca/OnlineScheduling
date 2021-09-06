using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using OnlineSheduling.Domain.Infra.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineScheduling.Domain.Infra.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DataContext context) : base(context)
        {
        }

        public Schedule GetById(long id)
        {
            return _context.Schedules.AsNoTracking().FirstOrDefault(ScheduleQueries.GetById(id));
        }

        public IEnumerable<Schedule> GetSchedulesByPhone(string phone)
        {
            return _context.Schedules.AsNoTracking().Where(x => x.Custumer.Phone == phone).ToList();
        }

        public Schedule IsExists(DateTime scheduleDate)
        {
            return _context.Schedules.AsNoTracking().FirstOrDefault(x => x.ScheduleDate == scheduleDate && x.SheduleStatus == ScheduleEnum.Schedule);
        }
    }
}
