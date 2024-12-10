using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities;

public class Customer : Entitiy<int>
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public ICollection<Schedule> Schedules { get; private set; }
        
    private Customer() { }
    
    public void Update(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }
}