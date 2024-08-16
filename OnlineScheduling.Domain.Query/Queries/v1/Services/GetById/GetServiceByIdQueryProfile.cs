using AutoMapper;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.Services.GetById
{
    public sealed class GetServiceByIdQueryProfile : Profile
    {
        public GetServiceByIdQueryProfile()
        {
            CreateMap<Service, GetServiceByIdQueryResponse>();
        }
    }
}