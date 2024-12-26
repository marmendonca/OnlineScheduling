using MediatR;

namespace OnlineScheduling.Application.Commands.v1.ProfessionalServices.Create;

public class CreateProfessionalServiceCommand : IRequest<Unit>
{
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }
}