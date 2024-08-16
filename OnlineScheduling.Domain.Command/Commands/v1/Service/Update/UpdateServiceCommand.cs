using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Service.Update;

public sealed class UpdateServiceCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public TimeSpan? CompletionTime { get; set; }
    public bool Active { get; set; }
}