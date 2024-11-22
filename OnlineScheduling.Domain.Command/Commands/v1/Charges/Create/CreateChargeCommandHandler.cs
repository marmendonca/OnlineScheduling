using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create
{
    public sealed class CreateChargeCommandHandler : IRequestHandler<CreateChargeCommand, CreateChargeCommandResponse>
    {
        public Task<CreateChargeCommandResponse> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateChargeCommandResponse() { ChargeId = 0, QrCode = "" });
        }
    }
}