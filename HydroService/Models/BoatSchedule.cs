using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gold.Vikings.Models{
    public class BoatSchedule : ISchedule
    {
        [Key]
        public virtual int ScheduleId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string ScheduleComment { get; set; }
        public int BoatId{ get; set; } 
        public virtual Boat Boat{ get; set;}
    }

}