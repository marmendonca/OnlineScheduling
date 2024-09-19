using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface IProfessionalReadOnlyRepository
{
    Task<IEnumerable<Professional>> FindAsync();
    Task<Professional> GetByIdAsync(int id);
}