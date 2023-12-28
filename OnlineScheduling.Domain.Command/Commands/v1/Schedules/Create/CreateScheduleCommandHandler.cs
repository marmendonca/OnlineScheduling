using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories.v1;

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

        await _scheduleRepository.SaveAsync(schedule);

        return Unit.Value;
    }
}