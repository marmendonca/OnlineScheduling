using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;

public class CreateProfessionalCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
}