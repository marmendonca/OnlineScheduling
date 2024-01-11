using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules;

public sealed class ScheduleCommandProfile : Profile
{
    public ScheduleCommandProfile()
    {
        CreateMap<UpdateScheduleCommand, Schedule>();
        CreateMap<CreateScheduleCommand, Schedule>();
    }
}