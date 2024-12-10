using System.ComponentModel;

namespace OnlineScheduling.Domain.Enums;

public enum ScheduleStatus
{
    [Description("Agendado")]
    Schedule = 1,
    [Description("Pendente")]
    Pending = 2,
    [Description("Pendente pagamento")]
    PendingPayment = 3,
    [Description("Cancelado")]
    Canceled = 4
}