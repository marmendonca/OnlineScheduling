using System;
using System.Collections.Generic;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Entities;

public class Schedule : Entitiy<int>
{
    public int ServiceId { get; private set; }
    public int CustomerId { get; private set; }
    public int ProfessionalId { get; private set; }
    public DateTime ScheduleAt { get; private set; }
    public ScheduleStatus Status { get; set; }
    public virtual Service Service { get; private set; }
    public virtual Customer Customer { get; private set; }
    public virtual Professional Professional { get; private set; }
    public virtual Charge Charges { get; private set; }
        
    private Schedule() { }

    public void SetStatus(ScheduleStatus status)
        => Status = status;
    
    public void SetCustomer(Customer customer)
        => Customer = customer;
    
    public void SetService(Service service)
        => Service = service;
}