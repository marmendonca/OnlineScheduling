using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;

public class CreateProfessionalCommandHandler(IProfessionalRepository professionalRepository, IMapper mapper) : IRequestHandler<CreateProfessionalCommand, Unit>
{
    public async Task<Unit> Handle(CreateProfessionalCommand command, CancellationToken cancellationToken)
    {
        if (await professionalRepository.ExistProfessionalByCpfAsync(command.Cpf))
            throw new Exception("Já existe um profissional criado por esse cpf.");

        var professional = mapper.Map<Professional>(command);

        await professionalRepository.AddAsync(professional);
        
        return Unit.Value;
    }
}