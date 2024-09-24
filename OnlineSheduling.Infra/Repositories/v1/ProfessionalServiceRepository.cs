using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1
{
    public class ProfessionalServiceRepository : BaseRepository<ProfessionalService, int>, IProfessionalServiceRepository
    {
        public ProfessionalServiceRepository(DataContext context) : base(context)
        {
        }
    }
}