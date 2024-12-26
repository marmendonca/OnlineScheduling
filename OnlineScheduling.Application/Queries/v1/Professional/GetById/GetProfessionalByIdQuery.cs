using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Application.Queries.v1.Professional.GetById;

public class GetProfessionalByIdQuery : IRequest<GetProfessionalByIdQueryResponse>
{
    [FromRoute]
    public int Id { get; set; }
}