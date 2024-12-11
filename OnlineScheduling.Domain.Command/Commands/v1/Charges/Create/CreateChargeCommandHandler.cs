using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

public sealed class CreateChargeCommandHandler(
    IScheduleRepository scheduleRepository,
    ICustomerRepository customerRepository,
    IEfiBankService efiBankService,
    IChargeRepository chargeRepository,
    IEfiBankChargeRepository efiBankChargeRepository) : IRequestHandler<CreateChargeCommand, CreateChargeCommandResponse>
{
    public async Task<CreateChargeCommandResponse> Handle(CreateChargeCommand command, CancellationToken cancellationToken)
    {
        var scheduling = await scheduleRepository.GetByIdAsync(command.SchedulingId);
        var customer = await customerRepository.GetByIdAsync(command.CustomerId);

        var chargeDto = await efiBankService.CreateImmediateChargeAsync(customer, 1);

        var charge = new Charge(
            scheduling.Id,
            command.Value,
            ChargeStatus.Pending,
            Guid.Parse(chargeDto.TxId));

        var efiBankCharge = new EfiBankCharge(
            Guid.Parse(chargeDto.TxId), 
            Guid.Parse(chargeDto.SolicitationPaymentId), 
            chargeDto.LocationId,
            chargeDto.Status,
            chargeDto.ImageQrCode,
            chargeDto.LinkQrCode,
            chargeDto.PixCopyAndPaste);
        
        await chargeRepository.AddAsync(charge);
        await efiBankChargeRepository.AddAsync(efiBankCharge);
        
        scheduling.SetStatus(ScheduleStatus.PendingPayment);
        
        await scheduleRepository.UpdateAsync(scheduling);
            
        return new CreateChargeCommandResponse() { ChargeId = charge.Id, LinkQrCode = efiBankCharge.LinkQrCode, ImageQrCode = efiBankCharge.ImageQrCode};
    }

        
}