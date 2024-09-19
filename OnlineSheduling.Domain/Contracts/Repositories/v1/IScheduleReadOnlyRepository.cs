using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface IScheduleReadOnlyRepository
{
    Task<IEnumerable<Schedule>> FindAsync();
    Task<Schedule> GetByIdAsync(int id);
}