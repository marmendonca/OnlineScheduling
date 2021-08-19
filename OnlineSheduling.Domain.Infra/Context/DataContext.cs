using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ServiceSchedule> ServiceSchedules { get; set; }

        public DbSet<Custumer> Custumers { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }
}
