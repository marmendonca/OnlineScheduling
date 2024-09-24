using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;

public class UpdateProfessionalServiceCommandHandler(
    IProfessionalServiceRepository professionalServiceRepository,
    IMapper mapper) : IRequestHandler<UpdateProfessionalServiceCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProfessionalServiceCommand command, CancellationToken cancellationToken)
    {
        var professionalService = await professionalServiceRepository
            .GetByIdAsync(command.Id) ?? throw new InvalidDataException("Não foi encontrado o vinculo de profissional e serviço informado.");

        mapper.Map(command, professionalService);

        await professionalServiceRepository.UpdateAsync(professionalService);

        return Unit.Value;
    }
}