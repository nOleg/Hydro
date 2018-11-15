using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gold.Vikings.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HydroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
 
  // GET api/values
        [HttpGet]
        //[RequireHttps]
        public ActionResult<Ticket> Get()
        {
            
             return new Ticket(){tik=Guid.NewGuid(),tms=DateTime.Now};
        }
 
    }

    public class Ticket{
            public Guid tik { get; set; }
            public DateTime tms { get; set; }
            
           
            
            
            public string hashCode {
                  get{
                        return  Encoding.UTF8.GetString(SHA256.Create().ComputeHash(tik.ToByteArray()));
                      }
                }
        }
    
    }
