using System;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Entities;

public class EfiBankCharge : Entitiy<Guid>
{
    public Guid SolicitationPaymentId { get; private set; }
    public int LocationId { get; private set; }
    public EfiBankChargeStatus Status { get; private set; }
    public string ImageQrCode { get; private set; }
    public string LinkQrCode { get; private set; }
    public string PixCopyAndPaste { get; private set; }

    public EfiBankCharge(
        Guid id,
        Guid solicitationPaymentId, 
        int locationId, 
        EfiBankChargeStatus status,
        string imageQrCode,
        string linkQrCode,
        string pixCopyAndPaste)
    {
        Id = id;
        SolicitationPaymentId = solicitationPaymentId;
        LocationId = locationId;
        Status = status;
        ImageQrCode = imageQrCode;
        LinkQrCode = linkQrCode;
        PixCopyAndPaste = pixCopyAndPaste;
    }

    private EfiBankCharge()
    { }
}