using AutoMapper;
using OnlineScheduling.Application.Commands.v1.Professionals.Create;
using OnlineScheduling.Application.Commands.v1.Professionals.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Mappers;

public class ProfessionalProfile : Profile
{
    public ProfessionalProfile()
    {
        CreateMap<CreateProfessionalCommand, Professional>();
        CreateMap<UpdateProfessionalCommand, Professional>();
    }
}