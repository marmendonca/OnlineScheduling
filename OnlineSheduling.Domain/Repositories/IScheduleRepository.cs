using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule GetById(long id);
    }
}
