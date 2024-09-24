using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Unit>
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = _mapper.Map<Schedule>(command);
        
        schedule.SetActive(true);

        await _scheduleRepository.AddAsync(schedule);

        return Unit.Value;
    }
}