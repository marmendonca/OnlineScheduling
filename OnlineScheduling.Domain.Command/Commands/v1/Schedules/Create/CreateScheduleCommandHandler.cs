using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    : IRequestHandler<CreateScheduleCommand, Unit>
{
    public async Task<Unit> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = mapper.Map<Schedule>(command);
        
        schedule.SetActive(true);

        await scheduleRepository.AddAsync(schedule);

        return Unit.Value;
    }
}