using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById
{
    public sealed class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResponse>
    {
        private readonly IServiceReadOnlyRepository _serviceReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IMapper mapper, IServiceReadOnlyRepository serviceReadOnlyRepository)
        {
            _serviceReadOnlyRepository = serviceReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResponse> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
        {
            var service = await _serviceReadOnlyRepository.GetByIdAsync(query.Id);
            
            return _mapper.Map<GetServiceByIdQueryResponse>(service);
        }
    }
}