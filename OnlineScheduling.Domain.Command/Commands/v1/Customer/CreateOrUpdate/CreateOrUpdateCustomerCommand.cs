using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.CreateOrUpdate;

public sealed class CreateOrUpdateCustomerCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
}