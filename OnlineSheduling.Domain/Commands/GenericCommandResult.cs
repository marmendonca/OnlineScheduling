using OnlineScheduling.Domain.Commands.Contracts;

namespace OnlineScheduling.Domain.Commands
{
    public class GenericCommandResult : IGenericCommandResult
    {
        public GenericCommandResult()
        {
        }

        public GenericCommandResult(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
