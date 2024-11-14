using MediatR;

namespace OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByProfessional
{
    public sealed class GetServicesByProfessionalQuery(int professionalId) : IRequest<IEnumerable<GetServicesByProfessionalQueryResponse>>
    {
        public int ProfessionalId { get; set; } = professionalId;
    }
}