using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class ChargeRepository(DataContext context)
    : BaseRepository<Charge, int>(context), IChargeRepository
{
    public async Task<Charge> GetPendingChargeByScheduleIdAndValueAsync(int scheduleId, decimal value)
    {
        return await _context.Charges
            .FirstOrDefaultAsync(x => x.ScheduleId == scheduleId &&
                                      x.Value == value &&
                                      x.Status == ChargeStatus.Pending);
    }
}