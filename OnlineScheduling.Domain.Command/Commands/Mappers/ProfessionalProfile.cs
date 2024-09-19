using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.Mappers
{
    public class ProfessionalProfile : Profile
    {
        public ProfessionalProfile()
        {
            CreateMap<CreateProfessionalCommand, Professional>();
            CreateMap<UpdateProfessionalCommand, Professional>();
        }
    }
}