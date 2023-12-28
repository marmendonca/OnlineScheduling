using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.Profiles;

public sealed class ScheduleProfile : Profile
{
    public ScheduleProfile()
    {
        CreateMap<CreateScheduleCommand, Schedule>();
    }
}