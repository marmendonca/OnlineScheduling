using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings
{
    public class ProfessionalMap : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable(nameof(Professional));
            builder.HasKey(professional => professional.Id);
            builder.Property(professional => professional.Name).HasColumnType("VARCHAR(100)");
            builder.Property(professional => professional.Cpf).HasColumnType("VARCHAR(11)");
            builder.Property(professional => professional.BirthDate).HasColumnType("DATETIME2");
        }
    }
}