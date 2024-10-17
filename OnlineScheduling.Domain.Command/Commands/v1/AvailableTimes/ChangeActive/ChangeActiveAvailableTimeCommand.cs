using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableTimes.ChangeActive
{
    public sealed class ChangeActiveAvailableTimeCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}