using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;

public sealed class UpdateServiceCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public required string Name { get; set; }
}