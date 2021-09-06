using System;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Entities
{
    public class DateScheduling : Entity
    {
        public DateScheduling()
        {
        }

        public DateScheduling(DateTime dateSchedule, string hourSchedule, bool hasSchedule)
        {
            DateSchedule = dateSchedule;
            HourSchedule = hourSchedule;
            HasSchedule = hasSchedule;
        }

        public DateTime DateSchedule { get; set; }

        public string HourSchedule { get; set; }

        public bool HasSchedule { get; set; }
    
        //public void CreateHours()
        //{
        //    List<int> Hours = new List<int>();

        //    for ()
        //}
    }
}
