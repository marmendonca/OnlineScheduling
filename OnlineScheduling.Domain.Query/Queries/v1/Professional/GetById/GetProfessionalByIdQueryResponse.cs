namespace OnlineScheduling.Domain.Query.Queries.v1.Professional.GetById
{
    public class GetProfessionalByIdQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }

        public static explicit operator GetProfessionalByIdQueryResponse(Entities.Professional professional)
        {
            return new()
            {
                Id = professional.Id,
                CreatedAt = professional.CreatedAt,
                Name = professional.Name,
                Cpf = professional.Cpf,
                BirthDate = professional.BirthDate,
            };
        }
    }
}