using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;

public class CreateProfessionalServiceCommand : IRequest<Unit>
{
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }
}