using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings;

public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Name).HasColumnType("VARCHAR(100)");
        builder.Property(customer => customer.Phone).HasColumnType("VARCHAR(20)");
        builder.Property(customer => customer.Email).HasColumnType("VARCHAR(20)");
    }
}