using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Service> Services { get; set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<ProfessionalService> ProfessionalServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}