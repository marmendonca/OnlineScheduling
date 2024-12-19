using MediatR;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.UpdateStatus;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

public sealed class CreateChargeCommandHandler(
    ICustomerRepository customerRepository,
    IEfiBankService efiBankService,
    IChargeRepository chargeRepository,
    IEfiBankChargeRepository efiBankChargeRepository,
    IMediator mediator) : IRequestHandler<CreateChargeCommand, CreateChargeCommandResponse>
{
    public async Task<CreateChargeCommandResponse> Handle(CreateChargeCommand command, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(command.CustomerId);

        var chargeResponse = await GetExistingChargeAsync(command.SchedulingId, command.Value);
        if (chargeResponse is not null)
            return chargeResponse;
        
        chargeResponse = await CreateChargeAsync(customer, command.SchedulingId, command.Value);
        
        await SetSchedulingToPendingPaymentAsync(command.SchedulingId);

        return chargeResponse;
    }
    
    private async Task<CreateChargeCommandResponse> GetExistingChargeAsync(int schedlingId, decimal value)
    {
        var charge = await chargeRepository.GetPendingChargeByScheduleIdAndValueAsync(schedlingId, value);
        if (charge is null)
            return null;
        
        var efiBankCharge = await efiBankChargeRepository.GetByIdAsync(charge.EfiBankChargeId.GetValueOrDefault());

        return new CreateChargeCommandResponse
        {
            ChargeId = charge.Id,
            LinkQrCode = efiBankCharge.LinkQrCode,
            ImageQrCode = efiBankCharge.ImageQrCode
        };
    }

    private async Task<CreateChargeCommandResponse> CreateChargeAsync(Entities.Customer customer, int scheduleId, decimal value)
    {
        var chargeDto = await efiBankService.CreateImmediateChargeAsync(customer, 1);

        var charge = new Charge(
            scheduleId,
            value,
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
        
        return new CreateChargeCommandResponse
        {
            ChargeId = charge.Id, LinkQrCode = efiBankCharge.LinkQrCode, ImageQrCode = efiBankCharge.ImageQrCode
        };
    }

    private async Task SetSchedulingToPendingPaymentAsync(int scheduleId)
    {
        await mediator.Send(new UpdateScheduleStatusCommand(scheduleId, ScheduleStatus.PendingPayment));
    }
}