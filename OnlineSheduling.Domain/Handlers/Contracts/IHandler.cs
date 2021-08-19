using OnlineScheduling.Domain.Commands.Contracts;

namespace OnlineScheduling.Domain.Handlers.Contracts
{
    public interface IHandler <T> where T : ICommand
    {
        IGenericCommandResult Handle(T command);
    }
}
