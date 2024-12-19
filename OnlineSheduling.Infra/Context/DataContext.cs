using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Service> Services { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<ProfessionalService> ProfessionalServices { get; set; }
    public DbSet<Charge> Charges { get; set; }
    public DbSet<EfiBankCharge> EfiBankCharges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}