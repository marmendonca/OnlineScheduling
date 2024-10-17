using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public class AvailableTimeMap : IEntityTypeConfiguration<AvailableTime>
{
    public void Configure(EntityTypeBuilder<AvailableTime> builder)
    {
        builder.ToTable(nameof(AvailableTime));
        builder.HasKey(available => available.Id);
        builder.Property(available => available.StartTime).HasColumnType("TIME");
        builder.Property(available => available.EndTime).HasColumnType("TIME");
        builder.Property(available => available.Interval).HasColumnType("INT");
        builder.Property(available => available.Active).HasColumnType("INT");
            
        builder.Property(available => available.ProfessionalId)
            .IsRequired(false)
            .HasDefaultValue(0)
            .HasColumnType("INT");

        builder.HasOne(available => available.Professional);
    }
}