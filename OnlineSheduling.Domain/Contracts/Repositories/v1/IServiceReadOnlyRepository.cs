using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface IServiceReadOnlyRepository
{
    Task<IEnumerable<Service>> FindAsync();
    Task<Service> GetByIdAsync(int id);
}