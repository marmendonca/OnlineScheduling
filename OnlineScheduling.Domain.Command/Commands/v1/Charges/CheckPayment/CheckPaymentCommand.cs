using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.CheckPayment;

public sealed class CheckPaymentCommand(int id) : IRequest<bool>
{
    public int Id { get; set; } = id;
}