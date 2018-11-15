using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gold.Vikings.Models{

    public class Boat : IBoat
    {
        [Key]
        public int BoatId { get; set; }
        public string BoatName { get; set; }
        public string BoatNumber { get; set; }
        public bool BoatActive { get; set; }
        public string BoatComment { get; set; }
        public virtual ICollection<BoatSchedule> BoatSchedule{ get; set; }
        // public Boat(){
        //     this.BoatSchedule= new HashSet<BoatSchedule>();
        // }

    }
}