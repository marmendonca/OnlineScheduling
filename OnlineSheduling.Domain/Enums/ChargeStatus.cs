using System.ComponentModel;

namespace OnlineScheduling.Domain.Enums;

public enum ChargeStatus
{
    [Description("Paga")]
    Paid = 1,
    [Description("Pendente")]
    Pending = 2,
    [Description("Cancelada")]
    Canceled = 3
}