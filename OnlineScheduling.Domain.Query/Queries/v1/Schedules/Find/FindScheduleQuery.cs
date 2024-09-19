using MediatR;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.Find;

public class FindScheduleQuery : IRequest<List<FindScheduleQueryResponse>>
{
        
}