using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Service.Create;

public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Unit>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Entities.Service>(command);

        await _serviceRepository.AddAsync(service);

        return Unit.Value;
    }
}