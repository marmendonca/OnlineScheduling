namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create
{
    public class CreateChargeCommandResponse
    {
        public string QrCode { get; set; }
        public int ChargeId { get; set; }
    }
}