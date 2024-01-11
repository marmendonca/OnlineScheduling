using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQuery : IRequest<GetScheduleByIdQueryResponse>
{
    [FromRoute]
    public int Id { get; set; }
}