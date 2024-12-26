using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Application.Commands.v1.AvailableDates.Create;

public sealed class CreateAvailableDateCommandHandler(IMapper mapper, IAvailableDateRepository availableDateRepository) : IRequestHandler<CreateAvailableDateCommand, Unit>
{
    public async Task<Unit> Handle(CreateAvailableDateCommand command, CancellationToken cancellationToken)
    {
        var availableTime = mapper.Map<AvailableDate>(command);

        await availableDateRepository.AddAsync(availableTime);
            
        return Unit.Value;
    }
}