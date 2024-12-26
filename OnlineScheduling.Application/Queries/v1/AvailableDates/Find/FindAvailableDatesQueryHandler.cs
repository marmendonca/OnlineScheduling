using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Application.Queries.v1.AvailableDates.Find;

public sealed class FindAvailableDatesQueryHandler(IAvailableDateReadOnlyRepository availableDateReadOnlyRepository) : IRequestHandler<FindAvailableDatesQuery, IEnumerable<FindAvailableDatesQueryResponse>>
{
    public async Task<IEnumerable<FindAvailableDatesQueryResponse>> Handle(FindAvailableDatesQuery query, CancellationToken cancellationToken)
    {
        var results = await availableDateReadOnlyRepository.FindAsync(query.ProfessionalId, query.Active);
            
        return results is null ? [] : results.Select(date => (FindAvailableDatesQueryResponse)date);
    }
}