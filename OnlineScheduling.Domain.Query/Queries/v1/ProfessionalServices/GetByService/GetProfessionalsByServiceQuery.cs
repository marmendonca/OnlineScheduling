using MediatR;

namespace OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByService
{
    public sealed class GetProfessionalsByServiceQuery(int serviceId) : IRequest<IEnumerable<GetProfessionalsByServiceQueryResponse>>
    {
        public int ServiceId { get; set; } = serviceId;
    }
}