using OnlineScheduling.Domain.Entities;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IServiceScheduleRepository : IRepository<ServiceSchedule>
    {
        ServiceSchedule IsExist(string serviceName);

        IEnumerable<ServiceSchedule> GetAll();
    }
}
