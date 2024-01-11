using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        builder.HasKey(schedule => schedule.Id);
        builder.Property(schedule => schedule.Name).HasColumnType("VARCHAR(100)");
        builder.Property(schedule => schedule.Phone).HasColumnType("VARCHAR(20)");
        builder.Property(schedule => schedule.Email).HasColumnType("VARCHAR(20)");
    }
}