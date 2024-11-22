using System;

namespace OnlineScheduling.Domain.Dtos;

public class ProfessionalServiceDto
{
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public decimal ServiceValue { get; set; }
    public TimeSpan ServiceCompletionTime { get; set; }
}