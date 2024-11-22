using System.ComponentModel;

namespace OnlineScheduling.Domain.Enums;

public enum ScheduleStatus
{
    [Description("Agendado")]
    Schedule = 1,
    [Description("Pendente")]
    Pending = 2,
    [Description("Cancelado")]
    Canceled = 3
}