using AutoMapper;
using FluentValidation;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;

public sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<CreateCustomerCommand, Unit>
{
    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (await customerRepository.ExistCustomerByEmailOrPhone(command.Email, command.Phone))
            throw new Exception("Já existe um usuário com os dados de email ou celular.");
        
        var customer = mapper.Map<Entities.Customer>(command);

        await customerRepository.AddAsync(customer);

        return Unit.Value;
    }
}