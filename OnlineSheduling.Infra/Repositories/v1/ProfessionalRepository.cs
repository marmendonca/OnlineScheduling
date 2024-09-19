using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1
{
    public class ProfessionalRepository : BaseRepository<Professional, int>, IProfessionalRepository
    {
        public ProfessionalRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> ExistProfessionalByCpfAsync(string cpf)
        {
            return await _context.Professionals.AnyAsync(professional => professional.Cpf == cpf);
        }
    }
}