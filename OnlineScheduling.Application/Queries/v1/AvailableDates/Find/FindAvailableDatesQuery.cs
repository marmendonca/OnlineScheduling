using MediatR;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Queries.v1.AvailableDates.Find;

public sealed class FindAvailableDatesQuery : IRequest<IEnumerable<FindAvailableDatesQueryResponse>>
{
    public int? ProfessionalId { get; set; }
    public bool Active { get; set; } = true;
}