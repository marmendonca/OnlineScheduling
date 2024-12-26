using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Schedules.Create;

public sealed class CreateScheduleCommand : IRequest<int>
{
    public int ServiceId { get; set; }
    public int CustomerId { get; set; }
    public int ProfessionalId { get; set; }
    public DateTime ScheduleAt { get; set; }
}