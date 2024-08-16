using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.Mappers;

public sealed class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<CreateCustomerCommand, Customer>();
    }
}