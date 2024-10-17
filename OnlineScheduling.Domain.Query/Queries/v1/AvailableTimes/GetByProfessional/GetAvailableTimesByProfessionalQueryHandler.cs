using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.AvailableTimes.GetByProfessional
{
    public sealed class GetAvailableTimesByProfessionalQueryHandler(IAvailableTimeReadOnlyRepository availableTimeReadOnlyRepository) : IRequestHandler<GetAvailableTimesByProfessionalQuery, GetAvailableTimesByProfessionalQueryResponse>
    {
        public async Task<GetAvailableTimesByProfessionalQueryResponse> Handle(GetAvailableTimesByProfessionalQuery query, CancellationToken cancellationToken)
        {
            var result = await availableTimeReadOnlyRepository.GetByProfessionalIdAsync(query.Professional);
            
            return (GetAvailableTimesByProfessionalQueryResponse)result;
        }
    }
}