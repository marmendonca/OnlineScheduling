using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Schedules.Update;

public sealed class UpdateScheduleCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateTime ScheduleAt { get; set; }
    public int ServiceId { get; set; }
    public int ProfessionalId { get; set; }
}