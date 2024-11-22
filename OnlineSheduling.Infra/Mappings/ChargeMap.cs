using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings
{
    public sealed class ChargeMap : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable(nameof(Charge));
            builder.HasKey(charge => charge.Id);
            builder.Property(charge => charge.ScheduleId).HasColumnType("INT");
            builder.Property(charge => charge.Value).HasColumnType("DECIMAL(10,2)");
            builder.Property(charge => charge.Status).HasColumnType("INT");
            builder.Property(charge => charge.CreatedTransactionId).HasColumnType("UNIQUEIDENTIFIER").IsRequired(false);
            builder.Property(charge => charge.CompletedTransactionId).HasColumnType("UNIQUEIDENTIFIER").IsRequired(false);
            
            builder.HasOne(charge => charge.Schedule)
                .WithMany(schedule => schedule.Charges)
                .HasForeignKey(charge => charge.ScheduleId);
        }
    }
}