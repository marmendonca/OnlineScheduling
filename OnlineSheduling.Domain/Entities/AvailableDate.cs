using System;

namespace OnlineScheduling.Domain.Entities;

public class AvailableDate : Entitiy<int>
{
    public int? ProfessionalId { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public int Interval { get; private set; }
    public bool Active { get; private set; }
        
    private AvailableDate() { }

    public void SetActive(bool active) => Active = active;
}