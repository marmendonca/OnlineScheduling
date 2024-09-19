using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;

public class UpdateProfessionalCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
}