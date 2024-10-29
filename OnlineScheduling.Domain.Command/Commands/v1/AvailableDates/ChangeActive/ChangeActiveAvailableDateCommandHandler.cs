using MediatR;
using OnlineScheduling.Domain.Contracts.Repositories.v1;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableDates.ChangeActive;

public sealed class ChangeActiveAvailableDateCommandHandler(IAvailableDateRepository availableDateRepository) : IRequestHandler<ChangeActiveAvailableDateCommand, Unit>
{
    public async Task<Unit> Handle(ChangeActiveAvailableDateCommand command, CancellationToken cancellationToken)
    {
        var availableTime = await availableDateRepository.GetByIdAsync(command.Id) 
                            ?? throw new InvalidDataException();
            
        availableTime.SetActive(command.Active);
            
        await availableDateRepository.UpdateAsync(availableTime);
            
        return Unit.Value;
    }
}