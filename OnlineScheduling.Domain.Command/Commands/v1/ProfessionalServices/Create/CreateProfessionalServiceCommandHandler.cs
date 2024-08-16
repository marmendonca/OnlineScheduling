using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;

public class CreateProfessionalServiceCommandHandler : IRequestHandler<CreateProfessionalServiceCommand, Unit>
{
    public Task<Unit> Handle(CreateProfessionalServiceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}