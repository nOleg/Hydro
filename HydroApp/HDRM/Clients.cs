using System;
using System.Collections.Generic;

namespace HydroApp.HDRM
{
    public partial class Clients
    {
        public Clients()
        {
            DayShedules = new HashSet<DayShedules>();
        }

        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientRegistred { get; set; }

        public ICollection<DayShedules> DayShedules { get; set; }
    }
}
