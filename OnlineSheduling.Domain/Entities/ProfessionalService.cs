namespace OnlineScheduling.Domain.Entities;

public class ProfessionalService : Entitiy<int>
{
    public int ProfessionalId { get; private set; }
    public int ServiceId { get; private set; }
    public virtual Professional Professional { get; private set; }
    public virtual Service Service { get; private set; }

    private ProfessionalService() { }
}