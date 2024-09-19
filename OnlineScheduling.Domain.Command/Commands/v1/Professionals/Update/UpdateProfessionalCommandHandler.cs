using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;

public class UpdateProfessionalCommandHandler(IProfessionalRepository professionalRepository, IMapper mapper) : IRequestHandler<UpdateProfessionalCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProfessionalCommand command, CancellationToken cancellationToken)
    {
        var professional = await professionalRepository.GetByIdAsync(command.Id);

        mapper.Map(command, professional);

        await professionalRepository.UpdateAsync(professional);

        return Unit.Value;
    }
}