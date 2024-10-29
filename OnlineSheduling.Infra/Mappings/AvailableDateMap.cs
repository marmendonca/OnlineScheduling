using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public class AvailableDateMap : IEntityTypeConfiguration<AvailableDate>
{
    public void Configure(EntityTypeBuilder<AvailableDate> builder)
    {
        builder.ToTable(nameof(AvailableDate));
        builder.HasKey(available => available.Id);
        builder.Property(available => available.StartAt).HasColumnType("DATETIME2");
        builder.Property(available => available.EndAt).HasColumnType("DATETIME2");
        builder.Property(available => available.Interval).HasColumnType("INT");
        builder.Property(available => available.Active).HasColumnType("INT");
            
        builder.Property(available => available.ProfessionalId)
            .IsRequired(false)
            .HasDefaultValue(0)
            .HasColumnType("INT");
    }
}