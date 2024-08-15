using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public sealed class ServiceMap : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(nameof(Service));
        builder.HasKey(service => service.Id);
        builder.Property(service => service.Name).HasColumnType("VARCHAR(200)");
        builder.Property(service => service.Value).HasColumnType("DECIMAL");
        builder.Property(service => service.CompletionTime).HasColumnType("TIME");
        builder.Property(service => service.Active).HasColumnType("BIT");
    }
}