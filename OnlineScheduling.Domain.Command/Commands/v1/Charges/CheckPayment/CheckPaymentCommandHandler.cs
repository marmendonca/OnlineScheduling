using MediatR;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.UpdateStatus;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Enums;
using OnlineScheduling.Domain.Exceptions;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.CheckPayment;

public sealed class CheckPaymentCommandHandler(
    IChargeRepository chargeRepository,
    IEfiBankService efiBankService,
    IMediator mediator) : IRequestHandler<CheckPaymentCommand, bool>
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
        await mediator.Send(new UpdateScheduleStatusCommand(scheduleId, ScheduleStatus.Schedule));
    }
}