using System.Threading.Tasks;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Services.v1;

public interface IEfiBankService
{
    Task CreateImmediateChargeAsync(Customer customer);
}