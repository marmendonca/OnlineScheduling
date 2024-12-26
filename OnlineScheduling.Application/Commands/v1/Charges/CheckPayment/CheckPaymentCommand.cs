using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Charges.CheckPayment;

public sealed class CheckPaymentCommand(int id) : IRequest<bool>
{
    public int Id { get; set; } = id;
}