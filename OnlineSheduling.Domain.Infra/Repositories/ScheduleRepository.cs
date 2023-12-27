﻿using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories;

public sealed class ScheduleRepository : BaseRepository<Schedule, int>, IScheduleRepository
{
    public ScheduleRepository(DataContext context) : base(context)
    {
    }
}