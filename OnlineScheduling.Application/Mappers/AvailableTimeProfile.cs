using AutoMapper;
using OnlineScheduling.Application.Commands.v1.AvailableDates.Create;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Mappers;

public class AvailableTimeProfile : Profile
{
    public AvailableTimeProfile()
    {
        CreateMap<CreateAvailableDateCommand, AvailableDate>();
    }
}