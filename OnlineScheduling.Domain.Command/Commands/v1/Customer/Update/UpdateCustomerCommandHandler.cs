using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var schedule = await _customerRepository.GetByIdAsync(command.Id);

        _mapper.Map(command, schedule);

        await _customerRepository.UpdateAsync(schedule);

        return Unit.Value;
    }
}