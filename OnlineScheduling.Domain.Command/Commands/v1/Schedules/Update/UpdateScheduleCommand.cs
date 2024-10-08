﻿using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;

public sealed class UpdateScheduleCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateTime ScheduleAt { get; set; }
    public int ServiceId { get; set; }
    public int ProfessionalId { get; set; }
}