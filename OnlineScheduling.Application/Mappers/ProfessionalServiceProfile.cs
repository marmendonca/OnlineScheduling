using AutoMapper;
using OnlineScheduling.Application.Commands.v1.ProfessionalServices.Create;
using OnlineScheduling.Application.Commands.v1.ProfessionalServices.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Mappers;

public class ProfessionalServiceProfile : Profile
{
    public ProfessionalServiceProfile()
    {
        CreateMap<UpdateProfessionalServiceCommand, ProfessionalService>();
        CreateMap<CreateProfessionalServiceCommand, ProfessionalService>();
    }
}