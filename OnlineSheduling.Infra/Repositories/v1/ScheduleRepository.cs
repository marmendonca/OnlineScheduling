using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class ScheduleRepository(DataContext context)
    : BaseRepository<Schedule, int>(context), IScheduleRepository
{
    public override async Task<Schedule> GetByIdAsync(int id)
    {
        return await _context.Schedules
            .Include(schedule => schedule.Customer)
            .Include(schedule => schedule.Service)
            .FirstOrDefaultAsync(schedule =>  schedule.Id == id);
    }
}