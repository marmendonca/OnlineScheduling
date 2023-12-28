using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories.v1;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class ServiceRepository : BaseRepository<Service, int>, IServiceRepository
{
    public ServiceRepository(DataContext context) : base(context)
    {
    }
}