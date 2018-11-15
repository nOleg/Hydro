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
    public class ClientsController : ControllerBase
    {


        private ApiContext db=new ApiContext();

        // GET api/values
        [HttpGet]
        //[RequireHttps]
        public async Task<ActionResult<ICollection<Client>>> Get()
        {
        //     var bts=db.Boats.Add(new Boat(){BoatName="sx-155"});

        
        // bts.Entity.ScheduleBoats.Add(new ScheduleBoat(){BoatNumber="ddddd1111",Comment="dfgddf dffgd dfg",Test=true,TimeStart=DateTime.Now,TimeEnd=DateTime.Now});

        //  db.Clients.Add(new Client(){ClientName="Олег", ClientPhone="1-111-11-11-1",ClientRegistred=DateTime.Now});
           
        //     db.SaveChanges();
            //bts.Reload();

           var tst=await Task.Run(()=>{
                  return (from c in db.Clients select c).ToList();
           });

           if(tst.Count()!=0){
            return tst;
           }else{
                return this.NotFound("Запись не найдена!");
           }


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  ActionResult<Client> Get(int id)
        {
            try{
                var res=(from c in db.Clients where c.ClientId==id select c).First();
                return res;
            }
            catch{
                return this.NotFound("Запись не найдена!");
            }
            
            
        }

        // POST api/values
        [HttpPost]
        public Client Post([FromBody] Client info)
        {
           
           
           var client= db.Clients.Add(new Client(){ClientName=info.ClientName, ClientPhone=info.ClientPhone, ClientRegistred=DateTime.Now});
            db.SaveChanges();
            client.Reload();
            return client.Entity;

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
