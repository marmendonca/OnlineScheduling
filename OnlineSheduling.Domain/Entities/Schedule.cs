namespace OnlineScheduling.Domain.Entities
{
    public class Schedule : Entitiy<int>
    {
        public int ServiceId { get; private set; }
        public int CustomerId { get; private set; }
        public virtual Service Service { get; private set; }
        public virtual Customer Customer { get; private set; }
    }
}