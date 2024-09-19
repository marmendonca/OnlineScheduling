using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface ICustomerRepository : IBaseRepository<Customer, int>
{
    Task<bool> ExistCustomerByEmailOrPhone(string email, string phone);
}