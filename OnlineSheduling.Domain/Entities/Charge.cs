using System;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Entities;

public class Charge : Entitiy<int>
{
    public int ScheduleId { get; private set; }
    public virtual Schedule Schedule { get; private set; }
    public decimal Value { get; private set; }
    public ChargeStatus Status { get; private set; }
    public Guid? EfiBankChargeId { get; private set; }
    
    private Charge() { }

    public Charge(int scheduleId, decimal value, ChargeStatus status, Guid efiBankChargeId)
    {
        ScheduleId = scheduleId;
        Value = value;
        Status = status;
        EfiBankChargeId = efiBankChargeId;
    }
}