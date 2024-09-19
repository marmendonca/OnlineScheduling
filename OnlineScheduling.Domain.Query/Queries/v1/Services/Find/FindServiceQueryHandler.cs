using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.Find
{
    public class FindServiceQueryHandler(IServiceReadOnlyRepository serviceReadOnlyRepository) : IRequestHandler<FindServiceQuery, List<FindServiceQueryResponse>>
    {
        public async Task<List<FindServiceQueryResponse>> Handle(FindServiceQuery request, CancellationToken cancellationToken)
        {
            var services = await serviceReadOnlyRepository.FindAsync();

            var response = services.Select(service => (FindServiceQueryResponse)service).ToList();

            return response;
        }
    }
}