using System;
using System.Collections.Generic;

namespace HydroApp.HDRM
{
    public partial class BoatSchedules
    {
        public long ScheduleId { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string ScheduleComment { get; set; }
        public long BoatId { get; set; }

        public Boats Boat { get; set; }
    }
}
