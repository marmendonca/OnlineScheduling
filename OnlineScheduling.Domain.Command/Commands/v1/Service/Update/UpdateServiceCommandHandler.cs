using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;

public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var schedule = await _serviceRepository.GetByIdAsync(command.Id);

        _mapper.Map(command, schedule);

        await _serviceRepository.UpdateAsync(schedule);

        return Unit.Value;
    }
}