namespace OnlineScheduling.Application.Queries.v1.Customer.GetByPhone;

public class GetCustomerByPhoneQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public static explicit operator GetCustomerByPhoneQueryResponse(Domain.Entities.Customer src)
    {
        return new()
        {
            Id = src.Id,
            Name = src.Name,
            Email = src.Email,
            Phone = src.Phone
        };
    }
}