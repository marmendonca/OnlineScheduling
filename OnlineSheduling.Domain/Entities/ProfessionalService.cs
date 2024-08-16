namespace OnlineScheduling.Domain.Entities;

public class ProfessionalService
{
    public int ProfessionalId { get; private set; }
    public int ServiceId { get; private set; }
    public Professional Professional { get; private set; }
    public Service Service { get; private set; }

    private ProfessionalService() { }
}