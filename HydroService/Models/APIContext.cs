using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Gold.Vikings.Models{

    public class ApiContext:DbContext{

        public static ApiContext db=>new ApiContext();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>optionsBuilder.UseSqlite("DataSource=app.db");

        public DbSet<DayShedule> DayShedules{get;set;}
        public DbSet<Client> Clients{get;set;}

        public DbSet<Boat> Boats{get;set;}

        public DbSet<BoatSchedule> BoatSchedules{get;set;}

        
       
       
       
       
       
       // public DbSet<ScheduleBoat> ScheduleBoats{get;set;}
    }


    // public class Boat{
    //     [Key]
    //    public int id{get;set;}
       
    //    [Required]
    //    public string BoatName{get;set;}

    //     public Boat()
    //     {
    //         this.ScheduleBoats = new HashSet<ScheduleBoat>();
    //     } 
    //     public virtual ICollection<ScheduleBoat> ScheduleBoats{ get; set; }


    // }

    //  public class ScheduleBoat{
      
    //    [Key]
    //    public int id{get;set;}

    //    [Required]
    //    public DateTime TimeStart{get;set;}

    //    [Required]
    //    public DateTime TimeEnd{get;set;}

    //     public string Comment{get;set;}

    //     public string BoatNumber{get;set;} 
        
    //     public bool Active{get;set;}

    //     public virtual Boat Boat { get; set; }

    //  }

    //  public class ScheduleDay{
       
    //    [Key]
    //    public int id{get;set;}

    //    [Required]
    //    public DateTime TimeStart{get;set;}

    //    [Required]
    //    public DateTime TimeEnd{get;set;}

    //    public string Comment{get;set;}

    //    public string BoatNumber{get;set;} 
        

    //  }

}
