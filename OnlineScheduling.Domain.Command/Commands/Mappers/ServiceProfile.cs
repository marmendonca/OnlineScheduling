using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Update;

namespace OnlineScheduling.Domain.Command.Commands.Mappers;

public sealed class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<UpdateServiceCommand, Entities.Service>();
        CreateMap<CreateServiceCommand, Entities.Service>();
    }
}