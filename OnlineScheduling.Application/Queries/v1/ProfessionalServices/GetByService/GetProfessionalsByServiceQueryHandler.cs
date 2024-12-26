using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Queries.v1.ProfessionalServices.GetByService;

public sealed class GetProfessionalsByServiceQueryHandler(IProfessionalServiceReadOnlyRepository professionalServiceReadOnlyRepository) : IRequestHandler<GetProfessionalsByServiceQuery, IEnumerable<GetProfessionalsByServiceQueryResponse>>
{
    public async Task<IEnumerable<GetProfessionalsByServiceQueryResponse>> Handle(GetProfessionalsByServiceQuery query, CancellationToken cancellationToken)
    {
        var professionals = await professionalServiceReadOnlyRepository
            .GetProfessionalsByServiceAsync(query.ServiceId);
            
        return professionals is null ? [] : professionals.Select(professional => (GetProfessionalsByServiceQueryResponse)professional);
    }
}