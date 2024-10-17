using MediatR;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.AvailableTimes.GetByProfessional
{
    public sealed class GetAvailableTimesByProfessionalQuery : IRequest<GetAvailableTimesByProfessionalQueryResponse>
    {
        public int? Professional { get; set; }
    }
}