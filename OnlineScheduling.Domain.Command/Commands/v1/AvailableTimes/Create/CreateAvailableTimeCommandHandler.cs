using AutoMapper;
using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableTimes.Create
{
    public sealed class CreateAvailableTimeCommandHandler(IMapper mapper, IAvailableTimeRepository availableTimeRepository) : IRequestHandler<CreateAvailableTimeCommand, Unit>
    {
        public async Task<Unit> Handle(CreateAvailableTimeCommand command, CancellationToken cancellationToken)
        {
            var availableTime = mapper.Map<AvailableTime>(command);

            await availableTimeRepository.AddAsync(availableTime);
            
            return Unit.Value;
        }
    }
}