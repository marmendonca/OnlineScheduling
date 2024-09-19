using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById;

public sealed class GetServiceByIdQueryHandler(IServiceReadOnlyRepository serviceReadOnlyRepository)
    : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResponse>
{
    public async Task<GetServiceByIdQueryResponse> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
    {
        var service = await serviceReadOnlyRepository.GetByIdAsync(query.Id);

        return (GetServiceByIdQueryResponse)service;
    }
}