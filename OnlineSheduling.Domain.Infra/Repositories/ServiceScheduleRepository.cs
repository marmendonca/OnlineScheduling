using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace OnlineScheduling.Domain.Infra.Repositories
{
    public class ServiceScheduleRepository : Repository<ServiceSchedule>, IServiceScheduleRepository
    {
        public ServiceScheduleRepository(DataContext context) : base(context)
        {
        }

        public ServiceSchedule IsExist(string serviceName)
        {
            return _context.ServiceSchedules.AsNoTracking().FirstOrDefault(x => x.ServiceName == serviceName);
        }

        public IEnumerable<ServiceSchedule> GetAll()
        {
            return _context.ServiceSchedules.AsNoTracking().ToList();
        }
    }
}
