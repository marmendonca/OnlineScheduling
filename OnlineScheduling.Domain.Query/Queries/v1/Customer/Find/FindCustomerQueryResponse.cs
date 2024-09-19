namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;

public class FindCustomerQueryResponse
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public static explicit operator FindCustomerQueryResponse(Entities.Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            CreatedAt = customer.CreatedAt,
            Email = customer.Email,
            Name = customer.Name,
            Phone = customer.Phone,
        };
    }
}