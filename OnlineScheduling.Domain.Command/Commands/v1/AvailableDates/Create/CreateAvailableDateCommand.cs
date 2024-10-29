using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableDates.Create;

public sealed class CreateAvailableDateCommand : IRequest<Unit>
{
    public int? ProfessionalId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int Interval { get; set; }
    public bool Active { get; set; } = true;
}