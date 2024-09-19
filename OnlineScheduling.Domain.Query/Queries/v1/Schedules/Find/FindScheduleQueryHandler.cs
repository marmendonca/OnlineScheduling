using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.Find;

public class FindScheduleQueryHandler(IScheduleReadOnlyRepository scheduleReadOnlyRepository) : IRequestHandler<FindScheduleQuery, List<FindScheduleQueryResponse>>
{
    public async Task<List<FindScheduleQueryResponse>> Handle(FindScheduleQuery request, CancellationToken cancellationToken)
    {
        var schedules = await scheduleReadOnlyRepository.FindAsync();

        var response = schedules.Select(schedule => (FindScheduleQueryResponse)schedule).ToList();
            
        return response;
    }
}