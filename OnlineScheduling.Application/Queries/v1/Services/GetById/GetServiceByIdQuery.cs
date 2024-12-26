using MediatR;

namespace OnlineScheduling.Application.Queries.v1.Services.GetById;

public sealed class GetServiceByIdQuery(int id) : IRequest<GetServiceByIdQueryResponse>
{
    public int Id { get; set; } = id;
}