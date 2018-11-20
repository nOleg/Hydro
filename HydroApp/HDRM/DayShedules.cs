using System;
using System.Collections.Generic;

namespace HydroApp.HDRM
{
    public partial class DayShedules
    {
        public long DaySheduleId { get; set; }
        public long ScheduleId { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string ScheduleComment { get; set; }
        public long BoatId { get; set; }
        public string BoatName { get; set; }
        public string BoatNumber { get; set; }
        public long BoatActive { get; set; }
        public string BoatComment { get; set; }
        public long? ClientId { get; set; }

        public Clients Client { get; set; }
    }
}
