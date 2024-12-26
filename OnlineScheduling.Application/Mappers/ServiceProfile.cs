using AutoMapper;
using OnlineScheduling.Application.Commands.v1.Service.Create;
using OnlineScheduling.Application.Commands.v1.Service.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Mappers;

public sealed class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<UpdateServiceCommand, Service>();
        CreateMap<CreateServiceCommand, Service>();
    }
}