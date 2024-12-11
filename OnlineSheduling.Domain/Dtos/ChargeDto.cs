using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Dtos;

public class ChargeDto
{
    public string ImageQrCode { get; set; }
    public string LinkQrCode { get; set; }
    public string PixCopyAndPaste { get; set; }
    public int LocationId { get; set; }
    public string SolicitationPaymentId { get; set; }
    public string TxId { get; set; }
    public EfiBankChargeStatus Status { get; set; }
}