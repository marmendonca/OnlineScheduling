using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Dtos;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1
{
    public interface IProfessionalServiceReadOnlyRepository
    {
        Task<IEnumerable<ProfessionalServiceDto>> GetServicesByProfessionalAsync(int professionalId);
    }
}