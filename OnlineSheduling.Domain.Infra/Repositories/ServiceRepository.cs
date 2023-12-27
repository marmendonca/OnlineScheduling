using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories;

public class ServiceRepository : BaseRepository<Service, int>, IServiceRepository
{
    public ServiceRepository(DataContext context) : base(context)
    {
    }
}