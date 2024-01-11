using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;

public sealed class UpdateCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
}