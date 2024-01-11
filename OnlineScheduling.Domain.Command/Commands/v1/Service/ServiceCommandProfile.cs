using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Update;

namespace OnlineScheduling.Domain.Command.Commands.v1.Schedules;

public sealed class ServiceCommandProfile : Profile
{
    public ServiceCommandProfile()
    {
        CreateMap<UpdateServiceCommand, Entities.Service>();
        CreateMap<CreateServiceCommand, Entities.Service>();
    }
}