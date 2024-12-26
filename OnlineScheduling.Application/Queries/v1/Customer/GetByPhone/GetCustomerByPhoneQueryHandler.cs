using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Queries.v1.Customer.GetByPhone;

public class GetCustomerByPhoneQueryHandler(ICustomerReadOnlyRepository customerReadOnlyRepository) : IRequestHandler<GetCustomerByPhoneQuery, GetCustomerByPhoneQueryResponse>
{
    public async Task<GetCustomerByPhoneQueryResponse> Handle(GetCustomerByPhoneQuery request, CancellationToken cancellationToken)
    {
        var result = await customerReadOnlyRepository.GetByPhoneAsync(request.Phone);
        return (GetCustomerByPhoneQueryResponse)result;
    }
}