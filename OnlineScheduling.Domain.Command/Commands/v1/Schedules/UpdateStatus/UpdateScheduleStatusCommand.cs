using MediatR;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.UpdateStatus;

public sealed class UpdateScheduleStatusCommand(int id, ScheduleStatus status) : IRequest<Unit>
{
    public int Id { get; set; } = id;
    public ScheduleStatus Status { get; set; } = status;
}