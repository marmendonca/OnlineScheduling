using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories.v1;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class ScheduleRepository : BaseRepository<Schedule, int>, IScheduleRepository
{
    public ScheduleRepository(DataContext context) : base(context)
    {
    }
}