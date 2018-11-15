using System.Collections.Generic;

namespace Gold.Vikings.Models{
   public interface IBoat{
       int BoatId{get;set;}
       string BoatName{get;set;}
       string BoatNumber{get;set;}
       bool BoatActive{ get; set;}
        string BoatComment{get; set;}
    }
}