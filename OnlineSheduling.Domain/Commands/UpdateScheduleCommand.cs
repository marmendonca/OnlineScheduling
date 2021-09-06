using OnlineScheduling.Domain.Commands.Contracts;
using OnlineScheduling.Domain.Enums;
using System;

namespace OnlineScheduling.Domain.Commands
{
    public class UpdateScheduleCommand : ICommand
    {
        public UpdateScheduleCommand()
        {
        }

        public UpdateScheduleCommand(string fullName, string phone, string serviceName, decimal serviceValue, TimeSpan serviceMinimumTime, DateTime scheduleDate, int scheduleHour, ScheduleEnum scheduleStatus)
        {
            FullName = fullName;
            Phone = phone;
            ServiceName = serviceName;
            ServiceValue = serviceValue;
            ServiceMinimumTime = serviceMinimumTime;
            ScheduleDate = scheduleDate;
            ScheduleHour = scheduleHour;
            ScheduleStatus = scheduleStatus;
        }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string ServiceName { get; set; }

        public decimal ServiceValue { get; set; }

        public TimeSpan ServiceMinimumTime { get; set; }

        public DateTime ScheduleDate { get; set; }

        public int ScheduleHour { get; set; }

        public ScheduleEnum ScheduleStatus { get; set; }
    }
}
