using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories;

public sealed class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }
}