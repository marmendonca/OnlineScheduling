using AutoMapper;
using OnlineScheduling.Application.Commands.v1.Schedules.Create;
using OnlineScheduling.Application.Commands.v1.Schedules.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Mappers;

public sealed class ScheduleProfile : Profile
{
    public ScheduleProfile()
    {
        CreateMap<UpdateScheduleCommand, Schedule>()
            .ForMember(dest => dest.ScheduleAt, opt => opt.MapFrom(src => src.ScheduleAt.AddHours(-3)));

        CreateMap<CreateScheduleCommand, Schedule>()
            .ForMember(dest => dest.ScheduleAt, opt => opt.MapFrom(src => src.ScheduleAt.AddHours(-3)));
    }
}