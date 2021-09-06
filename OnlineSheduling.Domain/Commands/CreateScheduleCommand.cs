﻿using OnlineScheduling.Domain.Commands.Contracts;
using OnlineScheduling.Domain.Enums;
using System;

namespace OnlineScheduling.Domain.Commands
{
    public class CreateScheduleCommand : ICommand
    {
        public CreateScheduleCommand()
        {
        }

        public CreateScheduleCommand(string fullName, string phone, string serviceName, decimal serviceValue, TimeSpan serviceMinimumTime, DateTime scheduleDate, string scheduleHour, ScheduleEnum scheduleStatus)
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

        public string ScheduleHour { get; set; }

        public ScheduleEnum ScheduleStatus { get; set; }
    }
}
