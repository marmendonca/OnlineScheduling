using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Service.Update;

public sealed class UpdateServiceCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public TimeSpan? CompletionTime { get; set; }
    public bool Active { get; set; }
}