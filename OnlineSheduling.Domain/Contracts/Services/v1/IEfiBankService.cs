using System.Threading.Tasks;
using OnlineScheduling.Domain.Dtos;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Contracts.Services.v1;

public interface IEfiBankService
{
    Task<ChargeDto> CreateImmediateChargeAsync(Customer customer, decimal value);
    Task<bool> CheckPaymentIsDoneAsync(string txId);
}