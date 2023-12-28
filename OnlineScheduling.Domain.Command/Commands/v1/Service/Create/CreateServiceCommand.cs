using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;

public sealed class CreateServiceCommand : IRequest<Unit>
{
    public required string Name { get; set; }
}