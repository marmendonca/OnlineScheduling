using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Service.Create;

public sealed class CreateServiceCommandHandler(
    IServiceRepository serviceRepository,
    IMapper mapper) : IRequestHandler<CreateServiceCommand, Unit>
{
    public async Task<Unit> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = mapper.Map<Entities.Service>(command);

        await serviceRepository.AddAsync(service);

        return Unit.Value;
    }
}