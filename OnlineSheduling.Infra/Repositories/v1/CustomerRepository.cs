using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }

    public async Task<bool> ExistCustomerByEmailOrPhone(string email, string phone)
    {
        return await _context.Customers
            .AnyAsync(customer => customer.Email == email || customer.Phone == phone);
    }
}