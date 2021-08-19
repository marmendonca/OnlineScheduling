using OnlineScheduling.Domain.Enums;
using System;

namespace OnlineScheduling.Domain.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
        }

        public Schedule(DateTime sheduleDate, TimeSpan sheduleHour, ScheduleEnum sheduleStatus, long shuduleServiceId, long custumerId)
        {
            SheduleDate = sheduleDate;
            SheduleHour = sheduleHour;
            SheduleStatus = sheduleStatus;
            ShuduleServiceId = shuduleServiceId;
            CustumerId = custumerId;
        }

        public DateTime SheduleDate { get; set; }

        public TimeSpan SheduleHour { get; set; }

        public ScheduleEnum SheduleStatus { get; set; }

        public long ShuduleServiceId { get; set; }

        public long CustumerId { get; set; }
    }
}
