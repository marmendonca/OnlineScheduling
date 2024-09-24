using System;

namespace OnlineScheduling.Domain.Entities;

public class Schedule : Entitiy<int>
{
    public int ServiceId { get; private set; }
    public int CustomerId { get; private set; }
    public int ProfessionalId { get; private set; }
    public DateTime ScheduleAt { get; private set; }
    public bool Active { get; private set; }
    public virtual Service Service { get; private set; }
    public virtual Customer Customer { get; private set; }
    public virtual Professional Professional { get; private set; }
        
    private Schedule() { }

    public void SetActive(bool active)
        => Active = active;
    
    public void SetCustomer(Customer customer)
        => Customer = customer;
    
    public void SetService(Service service)
        => Service = service;
}