using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Mappings
{
    public class ProfessionalServiceMap : IEntityTypeConfiguration<ProfessionalService>
    {
        public void Configure(EntityTypeBuilder<ProfessionalService> builder)
        {
            builder.HasKey(ps => new { ps.ServiceId, ps.ProfessionalId });
            
            builder.HasOne(ps => ps.Professional)
                .WithMany(p => p.Services)
                .HasForeignKey(ps => ps.ProfessionalId);

            builder.HasOne(ps => ps.Service)
                .WithMany(s => s.Professionals)
                .HasForeignKey(ps => ps.ServiceId);
        }
    }
}