using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;

public sealed class GetCustomerByIdQueryHandler(ICustomerReadOnlyRepository customerReadOnlyRepository) : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
{
    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerReadOnlyRepository.GetByIdAsync(request.Id);

        return (GetCustomerByIdQueryResponse)customer;
    }
}