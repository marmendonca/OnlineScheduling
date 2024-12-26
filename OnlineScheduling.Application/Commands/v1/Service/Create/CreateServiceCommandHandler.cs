using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Commands.v1.Service.Create;

public sealed class CreateServiceCommandHandler(
    IServiceRepository serviceRepository,
    IMapper mapper) : IRequestHandler<CreateServiceCommand, Unit>
{
    public async Task<Unit> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = mapper.Map<Domain.Entities.Service>(command);

        await serviceRepository.AddAsync(service);

        return Unit.Value;
    }
}