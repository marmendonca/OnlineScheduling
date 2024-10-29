using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class CustomerRepository(DataContext context)
    : BaseRepository<Customer, int>(context), ICustomerRepository
{
    public async Task<Customer> GetCustomerByEmailOrPhoneAsync(string email, string phone)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(customer => customer.Email == email || customer.Phone == phone);
    }
}