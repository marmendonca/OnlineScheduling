using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Service.Update;

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
        var service = await _serviceRepository
            .GetByIdAsync(command.Id) ?? throw new Exception("Usuário não encontrado.");

        _mapper.Map(command, service);

        await _serviceRepository.UpdateAsync(service);

        return Unit.Value;
    }
}