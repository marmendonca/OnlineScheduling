using AutoMapper;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;

public sealed class GetScheduleByIdQueryProfile : Profile
{
    public GetScheduleByIdQueryProfile()
    {
        CreateMap<Schedule, GetScheduleByIdQueryResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Customer.Phone))
            .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));
    }
}