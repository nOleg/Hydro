using System;
using System.ComponentModel.DataAnnotations;

namespace Gold.Vikings.Models{

    public class DayShedule : ISchedule, IBoat
    {
        [Key]
        public int DaySheduleId{ get; set;}
        public int ScheduleId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string ScheduleComment { get; set; }
        public int BoatId { get; set; }
        public string BoatName { get; set; }
        public string BoatNumber { get; set; }
        public bool BoatActive { get; set; }
        public string BoatComment { get; set; }
        
        
        public virtual Client Client{ get; set; }
        
    }

}