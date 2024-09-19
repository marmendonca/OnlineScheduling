using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Query.Queries.v1.Professional.Find;

namespace OnlineScheduling.Domain.Query.Queries.v1.Professional.GetById
{
    public class GetProfessionalByIdQueryHandler(IProfessionalReadOnlyRepository professionalReadOnlyRepository) : IRequestHandler<GetProfessionalByIdQuery, GetProfessionalByIdQueryResponse>
    {
        public async Task<GetProfessionalByIdQueryResponse> Handle(GetProfessionalByIdQuery query, CancellationToken cancellationToken)
        {
            var professional = await professionalReadOnlyRepository.GetByIdAsync(query.Id);

            return (GetProfessionalByIdQueryResponse)professional;
        }
    }
}