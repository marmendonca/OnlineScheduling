using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using System;

namespace OnlineScheduling.Domain.Infra.Repositories
{
    public class DateSchedulingRepository : Repository<DateScheduling>, IDateSchedulingRepository
    {
        public DateSchedulingRepository(DataContext context) : base(context)
        {
        }

        public DateTime GetDaysOfWeek()
        {
            var daysOfWeek = new DateTime();
            daysOfWeek.AddDays(7);
            return daysOfWeek;
        }
    }
}
