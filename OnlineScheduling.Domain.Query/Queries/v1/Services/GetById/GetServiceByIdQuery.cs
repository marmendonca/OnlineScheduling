using MediatR;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById
{
    public sealed class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}