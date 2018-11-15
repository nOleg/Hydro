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
    public class BoatController : ControllerBase
    {


        private ApiContext db=new ApiContext();





            // GET api/values
            [HttpGet]
            //[RequireHttps]
            public ActionResult<ICollection<Boat>> Get()
            {
            //     var bts=db.Boats.Add(new Boat(){BoatName="sx-155"});

            
            // bts.Entity.ScheduleBoats.Add(new ScheduleBoat(){BoatNumber="ddddd1111",Comment="dfgddf dffgd dfg",Test=true,TimeStart=DateTime.Now,TimeEnd=DateTime.Now});

            //  db.Clients.Add(new Client(){ClientName="Олег", ClientPhone="1-111-11-11-1",ClientRegistred=DateTime.Now});
            
            //     db.SaveChanges();
                //bts.Reload();

            //var tst=await Task.Run(()=>{
                    var tst= (from c in db.Boats select c).ToList();
            //});
    //c.BoatSchedule=(from b in db.BoatSchedules where b.BoatId==c.BoatId select b).ToList()}
            if(tst.Count()!=0){
                    return tst;
            }else{
                    return this.NotFound("Запись не найдена!");
            }


            }

        // GET api/values/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<Boat>> Get(int id)
        {
            try{
                var res=await Task.Run(()=>{ 
                var rs=(from c in db.Boats where c.BoatId==id select c).First();
                //rs.BoatSchedule=(from c in db.BoatSchedules where c.BoatId==id select c).ToList();
                return rs;
                });
                return res;
            }
            catch{

                return this.NotFound("Запись не найдена!");
            }
            
            
        }

         // GET api/values/5
        [HttpGet("{id}/schedule")]
        public  ActionResult<ICollection<BoatSchedule>> GetShedules(int id)
        {
            try{
                var rs=from c in db.BoatSchedules where c.BoatId==id select c;
                return rs.ToList();
            }
            catch{
                return this.NotFound("Запись не найдена!");
            }
        }

         // GET api/values/5
        [HttpGet("{id}/schedule/{idsdl}")]
        public  ActionResult<ICollection<BoatSchedule>> GetShedule(int idsdl)
        {
            try{
                var rs=from c in db.BoatSchedules where c.ScheduleId==idsdl select c;
                return rs.ToList();
            }
            catch{
                
                return this.NotFound("Запись не найдена!");
            }
        }

         [HttpPost("{id}")]
        public ICollection<Boat> Post()
        {
            return db.Boats.ToList();

        }

        // POST api/values
        [HttpPost]
        public async Task<Boat> Post([FromBody] Boat info)
        {
           
          var bot= await Task.Run(()=>{
           var boat= db.Boats.Add(new Boat(){
                  BoatName=info.BoatName,
                  BoatActive=info.BoatActive, 
                  BoatNumber=info.BoatNumber,
                  BoatComment=info.BoatComment,
                  BoatSchedule=info.BoatSchedule

                });


            db.SaveChanges();
            boat.Reload();
           return boat;
           });
            
            return bot.Entity;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
