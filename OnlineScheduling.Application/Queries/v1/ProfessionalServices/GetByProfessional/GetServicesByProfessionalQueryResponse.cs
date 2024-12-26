using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Queries.v1.ProfessionalServices.GetByProfessional;

public class GetServicesByProfessionalQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public TimeSpan CompletionTime { get; set; }
    public DateTime CreatedAt { get; set; }

    public static explicit operator GetServicesByProfessionalQueryResponse(Service src)
    {
        return new GetServicesByProfessionalQueryResponse
        {
            Id = src.Id,
            Name = src.Name,
            Value = src.Value,
            CompletionTime = src.CompletionTime.GetValueOrDefault(),
            CreatedAt = src.CreatedAt
        };
    }
}