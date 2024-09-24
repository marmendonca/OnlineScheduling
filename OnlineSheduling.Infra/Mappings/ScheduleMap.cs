using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public sealed class ScheduleMap : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable(nameof(Schedule));
        builder.HasKey(schedule => schedule.Id);
        builder.Property(schedule => schedule.ServiceId).HasColumnType("INT");
        builder.Property(schedule => schedule.CustomerId).HasColumnType("INT");
        builder.Property(schedule => schedule.ProfessionalId).HasColumnType("INT");
        builder.Property(schedule => schedule.ScheduleAt).IsRequired().HasColumnType("DATETIME2");
        builder.Property(schedule => schedule.Active).HasColumnType("INT");

        builder.HasOne(schedule => schedule.Service)
            .WithMany(service => service.Schedules)
            .HasForeignKey(schedule => schedule.ServiceId);

        builder.HasOne(schedule => schedule.Customer)
            .WithMany(customer => customer.Schedules)
            .HasForeignKey(schedule => schedule.CustomerId);
        
        builder.HasOne(schedule => schedule.Professional)
            .WithMany(professional => professional.Schedules)
            .HasForeignKey(schedule => schedule.ProfessionalId);
    }
}