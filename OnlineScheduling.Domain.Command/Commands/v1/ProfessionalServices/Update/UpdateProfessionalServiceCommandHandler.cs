using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;

public class UpdateProfessionalServiceCommandHandler : IRequestHandler<UpdateProfessionalServiceCommand, Unit>
{
    public Task<Unit> Handle(UpdateProfessionalServiceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}