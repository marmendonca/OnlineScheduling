using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommand : IRequest<Unit>
{
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
    public int ProfessionalId { get; set; }
    public DateTime ScheduleAt { get; set; }
}