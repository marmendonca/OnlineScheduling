using OnlineScheduling.Domain.Enums;
using System;

namespace OnlineScheduling.Domain.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
        }

        public Schedule(DateTime sheduleDate, TimeSpan sheduleHour, ScheduleEnum sheduleStatus, ServiceSchedule serviceSchedule, Custumer custumer)
        {
            SheduleDate = sheduleDate;
            SheduleHour = sheduleHour;
            SheduleStatus = sheduleStatus;
            ServiceSchedule = serviceSchedule;
            Custumer = custumer;
        }

        public DateTime SheduleDate { get; set; }

        public TimeSpan SheduleHour { get; set; }

        public ScheduleEnum SheduleStatus { get; set; }

        public ServiceSchedule ServiceSchedule { get; set; }

        public Custumer Custumer { get; set; }
    }
}
