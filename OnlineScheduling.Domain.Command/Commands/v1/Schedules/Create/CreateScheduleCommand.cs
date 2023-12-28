using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommand : IRequest<Unit>
{
    public DateTime ScheduleAt { get; set; }
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
}