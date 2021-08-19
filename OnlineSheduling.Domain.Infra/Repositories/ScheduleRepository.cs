﻿using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using OnlineSheduling.Domain.Infra.Queries;
using System.Linq;

namespace OnlineSheduling.Domain.Infra.Repositories
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
    }
}