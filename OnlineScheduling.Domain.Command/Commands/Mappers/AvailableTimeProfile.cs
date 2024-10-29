using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.AvailableDates.Create;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.Mappers;

public class AvailableTimeProfile : Profile
{
    public AvailableTimeProfile()
    {
        CreateMap<CreateAvailableDateCommand, AvailableDate>();
    }
}