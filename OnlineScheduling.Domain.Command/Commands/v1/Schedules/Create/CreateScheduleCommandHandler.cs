using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    : IRequestHandler<CreateScheduleCommand, int>
{
    public async Task<int> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = mapper.Map<Schedule>(command);
        
        schedule.SetStatus(ScheduleStatus.Pending);

        await scheduleRepository.AddAsync(schedule);

        return schedule.Id;
    }
}