using System;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Entities;

public class Charge : Entitiy<int>
{
    public int ScheduleId { get; private set; }
    public virtual Schedule Schedule { get; private set; }
    public decimal Value { get; private set; }
    public ChargeStatus Status { get; private set; }
    public Guid SolicitationPaymentId { get; private set; }
    public Guid? CompletedTransactionId { get; private set; }
    
    private Charge() { }
}