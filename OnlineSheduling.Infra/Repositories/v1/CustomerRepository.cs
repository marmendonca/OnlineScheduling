using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }
}