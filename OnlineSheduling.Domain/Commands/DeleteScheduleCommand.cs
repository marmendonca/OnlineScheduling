namespace OnlineSheduling.Domain.Commands
{
    public class DeleteScheduleCommand
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
