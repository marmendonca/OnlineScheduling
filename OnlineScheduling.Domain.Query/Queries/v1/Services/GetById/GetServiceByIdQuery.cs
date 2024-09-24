using MediatR;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById;

public sealed class GetServiceByIdQuery(int id) : IRequest<GetServiceByIdQueryResponse>
{
    public int Id { get; set; } = id;
}