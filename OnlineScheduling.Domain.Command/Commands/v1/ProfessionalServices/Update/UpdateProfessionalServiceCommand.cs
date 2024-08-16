using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;

public class UpdateProfessionalServiceCommand : IRequest<Unit>
{
    public int Id { get; set; }
}