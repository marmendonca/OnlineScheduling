using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Professional.Find
{
    public class FindProfessionalQueryHandler(IProfessionalReadOnlyRepository professionalReadOnlyRepository) : IRequestHandler<FindProfessionalQuery, List<FindProfessionalQueryResponse>>
    {
        public async Task<List<FindProfessionalQueryResponse>> Handle(FindProfessionalQuery request, CancellationToken cancellationToken)
        {
            var professionals = await professionalReadOnlyRepository.FindAsync();

            var response = professionals.Select(professional => (FindProfessionalQueryResponse)professional).ToList();
            
            return response;
        }
    }
}