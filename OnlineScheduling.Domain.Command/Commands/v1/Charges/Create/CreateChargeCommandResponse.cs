namespace OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

public class CreateChargeCommandResponse
{
    public string LinkQrCode { get; set; }
    public string ImageQrCode { get; set; }
    public int ChargeId { get; set; }
}