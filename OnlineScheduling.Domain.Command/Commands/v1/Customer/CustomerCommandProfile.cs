using AutoMapper;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer;

public sealed class CustomerCommandProfile : Profile
{
    public CustomerCommandProfile()
    {
        CreateMap<UpdateCustomerCommand, Entities.Customer>();
        CreateMap<CreateCustomerCommand, Entities.Customer>();
    }
}