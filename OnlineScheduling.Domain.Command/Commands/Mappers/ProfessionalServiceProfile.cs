using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.Mappers
{
    public class ProfessionalServiceProfile : Profile
    {
        public ProfessionalServiceProfile()
        {
            CreateMap<UpdateProfessionalServiceCommand, ProfessionalService>();
            CreateMap<CreateProfessionalServiceCommand, ProfessionalService>();
        }
    }
}