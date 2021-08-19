using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IServiceScheduleRepository : IRepository<ServiceSchedule>
    {
        ServiceSchedule IsExist(string serviceName);
    }
}
