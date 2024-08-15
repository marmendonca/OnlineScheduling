using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Entities.Customer>(command);

        await _customerRepository.AddAsync(customer);

        return Unit.Value;
    }
}