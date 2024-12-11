using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public sealed class EfiBankChargeMap : IEntityTypeConfiguration<EfiBankCharge>
{
    public void Configure(EntityTypeBuilder<EfiBankCharge> builder)
    {
        builder.ToTable(nameof(EfiBankCharge));
        builder.HasKey(efiBankCharge => efiBankCharge.Id);
        builder.Property(efiBankCharge => efiBankCharge.SolicitationPaymentId).HasColumnType("UNIQUEIDENTIFIER");
        builder.Property(efiBankCharge => efiBankCharge.LocationId).HasColumnType("INT");
        builder.Property(efiBankCharge => efiBankCharge.Status).HasColumnType("INT");
        builder.Property(efiBankCharge => efiBankCharge.ImageQrCode).HasColumnType("VARCHAR(5000)").IsRequired(false);
        builder.Property(efiBankCharge => efiBankCharge.LinkQrCode).HasColumnType("VARCHAR(500)").IsRequired(false);
        builder.Property(efiBankCharge => efiBankCharge.PixCopyAndPaste).HasColumnType("VARCHAR(2000)").IsRequired(false);
    }
}