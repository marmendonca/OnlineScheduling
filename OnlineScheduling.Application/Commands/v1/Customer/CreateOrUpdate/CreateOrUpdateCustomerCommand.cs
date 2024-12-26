using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Customer.CreateOrUpdate;

public sealed class CreateOrUpdateCustomerCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
}