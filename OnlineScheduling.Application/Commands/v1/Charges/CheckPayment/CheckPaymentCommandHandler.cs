using MediatR;
using OnlineScheduling.Application.Services.v1.Interfaces;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Exceptions;

namespace OnlineScheduling.Application.Commands.v1.Charges.CheckPayment;

public sealed class CheckPaymentCommandHandler(
    IChargeRepository chargeRepository,
    IEfiBankService efiBankService,
    IScheduleService scheduleService) : IRequestHandler<CheckPaymentCommand, bool>
{
    public async Task<bool> Handle(CheckPaymentCommand command, CancellationToken cancellationToken)
    {
        var charge = await chargeRepository.GetByIdAsync(command.Id) 
                     ?? throw new DomainException("Cobrança não encontrada");

        var paymentIsDone = await efiBankService
            .CheckPaymentIsDoneAsync("cda4aad136c74474886c6e70a55b58fa");

        if (!paymentIsDone) return false;

        await CompleteScheduleAsync(charge.ScheduleId);
            
        return true;
    }

    private async Task CompleteScheduleAsync(int scheduleId)
    {
        await scheduleService.CompleteScheduleAsync(scheduleId);
    }
}