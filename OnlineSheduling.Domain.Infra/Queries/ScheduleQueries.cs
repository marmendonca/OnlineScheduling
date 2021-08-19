using OnlineScheduling.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace OnlineSheduling.Domain.Infra.Queries
{
    public static class ScheduleQueries
    {
        public static Expression<Func<Schedule, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }
    }
}
