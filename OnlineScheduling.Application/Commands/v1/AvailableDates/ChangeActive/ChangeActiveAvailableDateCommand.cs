using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Application.Commands.v1.AvailableDates.ChangeActive;

public sealed class ChangeActiveAvailableDateCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public bool Active { get; set; }
}