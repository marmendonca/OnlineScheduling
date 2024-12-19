using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Exceptions;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.UpdateStatus;

public sealed class UpdateScheduleStatusCommandHandler(IScheduleRepository scheduleRepository) : IRequestHandler<UpdateScheduleStatusCommand, Unit>
{
    public async Task<Unit> Handle(UpdateScheduleStatusCommand command, CancellationToken cancellationToken)
    {
        var schedule = await scheduleRepository.GetByIdAsync(command.Id) 
                       ?? throw new DomainException("Agendamento não encontrado");
            
        schedule.SetStatus(command.Status);
            
        await scheduleRepository.UpdateAsync(schedule);
            
        return Unit.Value;
    }
}