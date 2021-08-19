using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;

namespace OnlineSheduling.Domain.Infra.Repositories
{
    public class ServiceScheduleRepository : Repository<ServiceSchedule>, IServiceScheduleRepository
    {
        public ServiceScheduleRepository(DataContext context) : base(context)
        {
        }
    }
}
