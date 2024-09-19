using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Domain.Query.Queries.v1.Professional.GetById
{
    public class GetProfessionalByIdQuery : IRequest<GetProfessionalByIdQueryResponse>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}