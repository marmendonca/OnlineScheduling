using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQueryHandler(
    IScheduleReadOnlyRepository scheduleReadOnlyRepository,
    IMapper mapper) : IRequestHandler<GetScheduleByIdQuery, GetScheduleByIdQueryResponse>
{
    public async Task<GetScheduleByIdQueryResponse> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await scheduleReadOnlyRepository.GetByIdAsync(request.Id);

        return (GetScheduleByIdQueryResponse)customer;
    }
}