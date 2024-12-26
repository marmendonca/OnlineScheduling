using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Service.Create;

public sealed class CreateServiceCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public TimeSpan? CompletionTime { get; set; }
    public bool Active { get; set; }
}