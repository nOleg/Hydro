using System;
using System.ComponentModel.DataAnnotations;

namespace Gold.Vikings.Models{
    public interface ISchedule{
        int ScheduleId{get;set;}
        DateTime TimeStart{get;set;}
        DateTime TimeEnd{get;set;}
        string ScheduleComment{get;set;}

     }
}