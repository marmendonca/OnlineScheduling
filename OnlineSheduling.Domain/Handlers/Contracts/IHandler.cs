using OnlineSheduling.Domain.Commands.Contracts;

namespace OnlineSheduling.Domain.Handlers.Contracts
{
    public interface IHandler <T> where T : ICommand
    {
        IGenericCommandResult Handle();
    }
}
