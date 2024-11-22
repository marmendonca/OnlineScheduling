namespace OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByService;

public sealed class GetProfessionalsByServiceQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
        
    public static explicit operator GetProfessionalsByServiceQueryResponse(Entities.Professional src)
    {
        return new GetProfessionalsByServiceQueryResponse
        {
            Id = src.Id,
            Name = src.Name,
            Cpf = src.Cpf,
            BirthDate = src.BirthDate,
            Email = src.Email,
            CreatedAt = src.CreatedAt
        };
    }
}