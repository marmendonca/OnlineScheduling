using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;

public class CreateProfessionalServiceCommandHandler(
    IProfessionalServiceRepository professionalServiceRepository,
    IMapper mapper) : IRequestHandler<CreateProfessionalServiceCommand, Unit>
{
    public async Task<Unit> Handle(CreateProfessionalServiceCommand command, CancellationToken cancellationToken)
    {
        var professionalService = mapper.Map<ProfessionalService>(command);

        await professionalServiceRepository.AddAsync(professionalService);

        return Unit.Value;
    }
}