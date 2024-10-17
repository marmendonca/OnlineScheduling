using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class AvailableTimeRepository : BaseRepository<AvailableTime, int>, IAvailableTimeRepository
{
    public AvailableTimeRepository(DataContext context) : base(context)
    {
    }
}