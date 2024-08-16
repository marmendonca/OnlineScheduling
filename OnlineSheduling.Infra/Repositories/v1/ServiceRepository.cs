using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class ServiceRepository : BaseRepository<Service, int>, IServiceRepository
{
    public ServiceRepository(DataContext context) : base(context)
    {
    }
}