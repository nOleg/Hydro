using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gold.Vikings.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HydroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduleController : ControllerBase
    {


        private ApiContext db=new ApiContext();
        
        
         // GET api/shedules/01.01.2011
        [HttpGet]
        public ActionResult<ICollection<DayShedule>> Get()
        {
        var tst= (from c in db.DayShedules select c).ToList();

            if(tst.Count()!=0){
                    return  tst  ;
            }else{
                    return this.NotFound("Запись не найдена!");
            }
        }

        
        
        
        
        // GET api/shedules/01.01.2011
        [HttpGet("{data}")]
        public ActionResult<ICollection<DayShedule>> Get(DateTime data)
        {
        var tst= (from c in db.DayShedules where c.TimeStart.ToShortDateString().Equals(data.ToShortDateString()) select c).ToList();

            if(tst.Count()!=0){
                    return  tst  ;
            }else{
                    return this.NotFound("Запись не найдена!");
            }
        }


        [HttpPost("{bid}")]
        public IEnumerable<DayShedule> Post(int bid)
        {

//   db.DayShedules.RemoveRange((db.DayShedules.ToList()));

//  db.SaveChanges();


IEnumerable<DayShedule> sel=from c in db.BoatSchedules where c.BoatId==bid select new DayShedule(){
                BoatName=c.Boat.BoatName,
                TimeStart=c.TimeStart,
                TimeEnd=c.TimeEnd,
                BoatId=c.BoatId,
                BoatComment=c.Boat.BoatComment,
                ScheduleComment=c.ScheduleComment,
                ScheduleId=c.ScheduleId,
                BoatActive=c.Boat.BoatActive,
                BoatNumber=c.Boat.BoatNumber};

            db.DayShedules.AddRange(sel);
            
            db.SaveChanges();
            return sel; //db.Boats.ToList();

        }







        // // GET api/values/5
        // [HttpGet("{id}")]
        // public  async Task<ActionResult<Boat>> Get(int id)
        // {
        //     try{
        //         var res=await Task.Run(()=>{ 
        //         var rs=(from c in db.Boats where c.BoatId==id select c).First();
        //         //rs.BoatSchedule=(from c in db.BoatSchedules where c.BoatId==id select c).ToList();
        //         return rs;
        //         });
        //         return res;
        //     }
        //     catch{

        //         return this.NotFound("Запись не найдена!");
        //     }
            
            
        // }

        //  // GET api/values/5
        // [HttpGet("{id}/schedule")]
        // public  ActionResult<ICollection<BoatSchedule>> GetShedules(int id)
        // {
        //     try{
        //         var rs=from c in db.BoatSchedules where c.BoatId==id select c;
        //         return rs.ToList();
        //     }
        //     catch{
        //         return this.NotFound("Запись не найдена!");
        //     }
        // }

        //  // GET api/values/5
        // [HttpGet("{id}/schedule/{idsdl}")]
        // public  ActionResult<ICollection<BoatSchedule>> GetShedule(int idsdl)
        // {
        //     try{
        //         var rs=from c in db.BoatSchedules where c.ScheduleId==idsdl select c;
        //         return rs.ToList();
        //     }
        //     catch{
                
        //         return this.NotFound("Запись не найдена!");
        //     }
        // }

        //  [HttpPost("{id}")]
        // public ICollection<Boat> Post()
        // {
        //     return db.Boats.ToList();

        // }

        // // POST api/values
        // [HttpPost]
        // public async Task<Boat> Post([FromBody] Boat info)
        // {
           
        //   var bot= await Task.Run(()=>{
        //    var boat= db.Boats.Add(new Boat(){
        //           BoatName=info.BoatName,
        //           BoatActive=info.BoatActive, 
        //           BoatNumber=info.BoatNumber,
        //           BoatComment=info.BoatComment,
        //           BoatSchedule=info.BoatSchedule

        //         });


        //     db.SaveChanges();
        //     boat.Reload();
        //    return boat;
        //    });
            
        //     return bot.Entity;

        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
