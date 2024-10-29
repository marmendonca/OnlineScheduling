using AutoMapper;
using FluentValidation;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.CreateOrUpdate;

public sealed class CreateOrUpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<CreateOrUpdateCustomerCommand, int>
{
    public async Task<int> Handle(CreateOrUpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var existCustomer = await customerRepository.GetCustomerByEmailOrPhoneAsync(command.Email, command.Phone);
        if (existCustomer is not null)
        {
            await UpdateCustomerAsync(existCustomer, command);
            return existCustomer.Id;
        }
        
        var customer = mapper.Map<Entities.Customer>(command);

        await customerRepository.AddAsync(customer);

        return customer.Id;
    }
    
    private async Task UpdateCustomerAsync(Entities.Customer customer, CreateOrUpdateCustomerCommand command)
    {
        customer.Update(command.Name, command.Phone, command.Email);
        
        await customerRepository.UpdateAsync(customer);
    }
}