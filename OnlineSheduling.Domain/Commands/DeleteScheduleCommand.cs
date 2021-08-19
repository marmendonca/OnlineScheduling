using OnlineScheduling.Domain.Commands.Contracts;

namespace OnlineScheduling.Domain.Commands
{
    public class DeleteScheduleCommand : ICommand
    {
        public DeleteScheduleCommand()
        {
        }

        public DeleteScheduleCommand(long scheduleId)
        {
            ScheduleId = scheduleId;
        }

        public long ScheduleId { get; set; }
    }
}
