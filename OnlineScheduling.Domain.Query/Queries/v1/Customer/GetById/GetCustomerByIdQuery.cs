using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;

public sealed class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResponse>
{
    public int Id { get; set; }

    public GetCustomerByIdQuery(int id)
    {
        Id = id;
    }
}