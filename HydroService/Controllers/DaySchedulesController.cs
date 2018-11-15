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
    public class SchedulesController : ControllerBase
    {


        private ApiContext db=new ApiContext();

        // GET api/values
        [HttpGet]
        //[RequireHttps]
        public async Task<ICollection<DayShedule>> Get()
        {
        //     var bts=db.Boats.Add(new Boat(){BoatName="sx-155"});

        
        // bts.Entity.ScheduleBoats.Add(new ScheduleBoat(){BoatNumber="ddddd1111",Comment="dfgddf dffgd dfg",Test=true,TimeStart=DateTime.Now,TimeEnd=DateTime.Now});

        //  db.DayShedules.Add(new DayShedule(){
        // TimeStart =DateTime.Now,
        // TimeEnd =DateTime.Now,

        // ScheduleComment { get; set; }
        // public int BoatId { get; set; }
        // public string BoatName { get; set; }
        // public string BoatNumber { get; set; }
        // public bool BoatActive { get; set; }
        // public string BoatComment { get; set; }
        // public virtual Client Client{ get; set; }  

        //  });
           
            db.SaveChanges();
            //bts.Reload();

           var tst=await Task.Run(()=>{
                  return (from c in db.DayShedules select c).ToList();
           });
           
            return tst;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  ActionResult<DayShedule> Get(int id)
        {
            try{
                var res=(from c in db.DayShedules where c.DaySheduleId==id select c).First();
                return res;
            }
            catch{
                return this.NotFound("Запись не найдена!");
            }
            
            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           

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
