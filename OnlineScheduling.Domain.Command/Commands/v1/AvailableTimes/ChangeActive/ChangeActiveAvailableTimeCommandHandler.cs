using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableTimes.ChangeActive
{
    public sealed class ChangeActiveAvailableTimeCommandHandler(IAvailableTimeRepository availableTimeRepository) : IRequestHandler<ChangeActiveAvailableTimeCommand, Unit>
    {
        public async Task<Unit> Handle(ChangeActiveAvailableTimeCommand command, CancellationToken cancellationToken)
        {
            var availableTime = await availableTimeRepository.GetByIdAsync(command.Id) 
                                ?? throw new InvalidDataException();
            
            availableTime.SetActive(command.Active);
            
            await availableTimeRepository.UpdateAsync(availableTime);
            
            return Unit.Value;
        }
    }
}