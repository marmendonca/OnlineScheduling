using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;

public sealed class CreateCustomerCommand : IRequest<Unit>
{
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
}