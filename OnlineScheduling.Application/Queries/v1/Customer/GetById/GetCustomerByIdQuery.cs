using MediatR;

namespace OnlineScheduling.Application.Queries.v1.Customer.GetById;

public sealed class GetCustomerByIdQuery(int id) : IRequest<GetCustomerByIdQueryResponse>
{
    public int Id { get; set; } = id;
}