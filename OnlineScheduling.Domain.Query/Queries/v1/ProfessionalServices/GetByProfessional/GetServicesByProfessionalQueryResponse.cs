using OnlineScheduling.Domain.Dtos;

namespace OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByProfessional
{
    public class GetServicesByProfessionalQueryResponse
    {
        public int ProfessionalId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal ServiceValue { get; set; }
        public TimeSpan ServiceCompletionTime { get; set; }

        public static explicit operator GetServicesByProfessionalQueryResponse(ProfessionalServiceDto src)
        {
            return new ()
            {
                ProfessionalId = src.ProfessionalId,
                ServiceId = src.ServiceId,
                ServiceName = src.ServiceName,
                ServiceValue = src.ServiceValue,
                ServiceCompletionTime = src.ServiceCompletionTime
            };
        }
    }
}