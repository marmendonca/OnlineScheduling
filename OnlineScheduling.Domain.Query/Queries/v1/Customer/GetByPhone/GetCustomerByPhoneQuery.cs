using MediatR;

namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.GetByPhone;

public class GetCustomerByPhoneQuery(string phone) : IRequest<GetCustomerByPhoneQueryResponse>
{
    public string Phone { get; set; } = phone;
}