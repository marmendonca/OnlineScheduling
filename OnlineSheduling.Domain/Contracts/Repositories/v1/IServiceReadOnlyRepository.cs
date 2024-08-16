using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface IServiceReadOnlyRepository
{
    Task<Service> GetByIdAsync(int id);
}