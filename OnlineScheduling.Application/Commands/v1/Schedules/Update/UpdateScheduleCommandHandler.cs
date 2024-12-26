using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Commands.v1.Schedules.Update;

public sealed class UpdateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    : IRequestHandler<UpdateScheduleCommand, Unit>
{
    public async Task<Unit> Handle(UpdateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = await scheduleRepository.GetByIdAsync(command.Id);

        mapper.Map(command, schedule);

        await scheduleRepository.UpdateAsync(schedule);

        return Unit.Value;
    }
}