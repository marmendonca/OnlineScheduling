using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;

public class FindCustomerQueryHandler(ICustomerReadOnlyRepository customerReadOnlyRepository) : IRequestHandler<FindCustomerQuery, List<FindCustomerQueryResponse>>
{
    public async Task<List<FindCustomerQueryResponse>> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await customerReadOnlyRepository.FindAsync();

        var response = customers.Select(customer => (FindCustomerQueryResponse)customer).ToList();
            
        return response;
    }
}