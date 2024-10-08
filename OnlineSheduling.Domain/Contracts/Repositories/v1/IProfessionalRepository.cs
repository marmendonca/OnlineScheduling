using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Repositories.v1
{
    public interface IProfessionalRepository : IBaseRepository<Professional, int>
    {
        Task<bool> ExistProfessionalByCpfAsync(string cpf);
    }
}