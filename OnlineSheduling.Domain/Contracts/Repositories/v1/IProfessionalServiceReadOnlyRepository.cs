using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Dtos;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1
{
    public interface IProfessionalServiceReadOnlyRepository
    {
        Task<IEnumerable<Service>> GetServicesByProfessionalAsync(int professionalId);
        Task<IEnumerable<Professional>> GetProfessionalsByServiceAsync(int serviceId);
    }
}