using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;

public sealed class CreateCustomerCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
}