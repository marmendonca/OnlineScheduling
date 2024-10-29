using MediatR;
using OnlineScheduling.Domain.Dtos;

namespace OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByProfessional
{
    public class GetServicesByProfessionalQuery(int professionalId) : IRequest<IEnumerable<GetServicesByProfessionalQueryResponse>>
    {
        public int ProfessionalId { get; set; } = professionalId;
    }
}