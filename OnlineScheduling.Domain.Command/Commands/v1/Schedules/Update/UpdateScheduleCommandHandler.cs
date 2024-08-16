using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;

public sealed class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, Unit>
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public UpdateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = await _scheduleRepository.GetByIdAsync(command.Id);

        _mapper.Map(command, schedule);

        await _scheduleRepository.UpdateAsync(schedule);

        return Unit.Value;
    }
}