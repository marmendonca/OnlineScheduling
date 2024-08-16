using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, GetScheduleByIdQueryResponse>
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public GetScheduleByIdQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<GetScheduleByIdQueryResponse> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _scheduleRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetScheduleByIdQueryResponse>(customer);
    }
}