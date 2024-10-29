using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Service.Update;

public sealed class UpdateServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    : IRequestHandler<UpdateServiceCommand, Unit>
{
    public async Task<Unit> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await serviceRepository
            .GetByIdAsync(command.Id) ?? throw new Exception("Usuário não encontrado.");

        mapper.Map(command, service);

        await serviceRepository.UpdateAsync(service);

        return Unit.Value;
    }
}