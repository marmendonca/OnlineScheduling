namespace OnlineScheduling.Application.Queries.v1.Customer.GetById;

public sealed class GetCustomerByIdQueryResponse
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public static explicit operator GetCustomerByIdQueryResponse(Domain.Entities.Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            CreatedAt = customer.CreatedAt,
            Name = customer.Name,
            Phone = customer.Phone,
            Email = customer.Email
        };
    }
}