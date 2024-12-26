using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Queries.v1.ProfessionalServices.GetByProfessional;

public class GetServicesByProfessionalQueryHandler(IProfessionalServiceReadOnlyRepository professionalServiceReadOnlyRepository) : IRequestHandler<GetServicesByProfessionalQuery, IEnumerable<GetServicesByProfessionalQueryResponse>>
{
    public async Task<IEnumerable<GetServicesByProfessionalQueryResponse>> Handle(GetServicesByProfessionalQuery query, CancellationToken cancellationToken)
    {
        var results = await professionalServiceReadOnlyRepository
            .GetServicesByProfessionalAsync(query.ProfessionalId);
            
        return results is null ? [] : results.Select(service => (GetServicesByProfessionalQueryResponse)service);
    }
}