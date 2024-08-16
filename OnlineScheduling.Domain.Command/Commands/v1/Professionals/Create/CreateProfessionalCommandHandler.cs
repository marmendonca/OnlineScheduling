using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;

public class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, Unit>
{
    public Task<Unit> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}