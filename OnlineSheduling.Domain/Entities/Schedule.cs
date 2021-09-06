using OnlineScheduling.Domain.Enums;
using System;

namespace OnlineScheduling.Domain.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
        }

        public Schedule(DateTime sheduleDate, ScheduleEnum sheduleStatus, ServiceSchedule serviceSchedule, Custumer custumer)
        {
            ScheduleDate = sheduleDate;
            SheduleStatus = sheduleStatus;
            ServiceSchedule = serviceSchedule;
            Custumer = custumer;
        }

        public DateTime ScheduleDate { get; set; }

        public ScheduleEnum SheduleStatus { get; set; }

        public ServiceSchedule ServiceSchedule { get; set; }

        public Custumer Custumer { get; set; }
    }
}
