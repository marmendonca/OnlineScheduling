using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

public sealed class CreateChargeCommand : IRequest<CreateChargeCommandResponse>
{
    public int SchedulingId { get; set; }
    public int CustomerId { get; set; }
    public decimal Value { get; set; }
}