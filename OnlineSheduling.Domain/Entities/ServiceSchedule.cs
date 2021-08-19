using System;

namespace OnlineScheduling.Domain.Entities
{
    public class ServiceSchedule : Entity
    {
        public ServiceSchedule()
        {
        }

        public ServiceSchedule(string serviceName, decimal serviceValue, TimeSpan minimumTime)
        {
            ServiceName = serviceName;
            ServiceValue = serviceValue;
            ServiceMinimumTime = minimumTime;
        }

        public string ServiceName { get; set; }

        public decimal ServiceValue { get; set; }

        public TimeSpan ServiceMinimumTime { get; set; }
    }
}