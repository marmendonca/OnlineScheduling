namespace OnlineScheduling.Domain.Entities
{
    public class Custumer : Entity
    {
        public Custumer()
        {
        }

        public Custumer(string fullName, string phone)
        {
            FullName = fullName;
            Phone = phone;
        }

        public string FullName { get; set; }

        public string Phone { get; set; }
    }
}
