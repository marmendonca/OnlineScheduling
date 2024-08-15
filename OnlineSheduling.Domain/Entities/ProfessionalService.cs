namespace OnlineScheduling.Domain.Entities
{
    public class ProfessionalService
    {
        public int ProfessionalId { get; set; }
        public int ServiceId { get; set; }
        public Professional Professional { get; set; }
        public Service Service { get; set; }
    }
}