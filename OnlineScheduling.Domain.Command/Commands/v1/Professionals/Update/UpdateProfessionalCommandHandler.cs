using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;

public class UpdateProfessionalCommandHandler : IRequestHandler<UpdateProfessionalCommand, Unit>
{
    public Task<Unit> Handle(UpdateProfessionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}