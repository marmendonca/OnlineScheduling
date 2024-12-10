using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Contracts.Services.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

public sealed class CreateChargeCommandHandler(
    IScheduleRepository scheduleRepository,
    ICustomerRepository customerRepository,
    IEfiBankService efiBankService) : IRequestHandler<CreateChargeCommand, CreateChargeCommandResponse>
{
    public async Task<CreateChargeCommandResponse> Handle(CreateChargeCommand command, CancellationToken cancellationToken)
    {
        var scheduling = await scheduleRepository.GetByIdAsync(command.SchedulingId);
        var customer = await customerRepository.GetByIdAsync(command.CustomerId);
            
        //scheduling.SetStatus(ScheduleStatus.PendingPayment);

        await efiBankService.CreateImmediateChargeAsync(customer);
            
        return new CreateChargeCommandResponse() { ChargeId = 0, QrCode = "" };
    }

        
}