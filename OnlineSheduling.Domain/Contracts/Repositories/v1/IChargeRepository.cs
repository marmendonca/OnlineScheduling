using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1;

public interface IChargeRepository : IBaseRepository<Charge, int>
{
    Task<Charge> GetPendingChargeByScheduleIdAndValueAsync(int scheduleId, decimal value);
}