using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class ProfessionalRepository(DataContext context)
    : BaseRepository<Professional, int>(context), IProfessionalRepository
{
    public async Task<bool> ExistProfessionalByCpfAsync(string cpf)
    {
        return await _context.Professionals.AnyAsync(professional => professional.Cpf == cpf);
    }
}