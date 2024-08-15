using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories.v1;
using OnlineScheduling.Infra.Context;
using System.Threading.Tasks;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class ScheduleRepository : BaseRepository<Schedule, int>, IScheduleRepository
{
    public ScheduleRepository(DataContext context) : base(context)
    {
    }

    public override async Task<Schedule> GetByIdAsync(int id)
    {
        return await _context.Schedules
            .Include(schedule => schedule.Customer)
            .Include(schedule => schedule.Service)
            .FirstOrDefaultAsync(schedule =>  schedule.Id == id);
    }
}