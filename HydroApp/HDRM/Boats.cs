using System;
using System.Collections.Generic;

namespace HydroApp.HDRM
{
    public partial class Boats
    {
        public Boats()
        {
            BoatSchedules = new HashSet<BoatSchedules>();
        }

        public long BoatId { get; set; }
        public string BoatName { get; set; }
        public string BoatNumber { get; set; }
        public long BoatActive { get; set; }
        public string BoatComment { get; set; }

        public ICollection<BoatSchedules> BoatSchedules { get; set; }
    }
}
