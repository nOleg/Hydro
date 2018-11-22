using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HydroApp.Models;
using System.Net;
using System.IO;
using HydroApp.HDRM;



namespace HydroApp.Controllers
{
    public class BoatController : Controller
    {


        appContext db=new appContext();
        public IActionResult Index()
        {
//             HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/boat/1");
//             //WebRequest req = WebRequest.Create("http://localhost:5000/api/boat/");
//             req.Method = "POST";
//             //req.Credentials = new NetworkCredential(username, password);
//             //req.ContentLength = sentData.Length;
//             //Stream sendStream = req.GetRequestStream();

//             //request.ContentLength = DataToPost.Length;
// //request.ContentType = "application/x-www-form-urlencoded";
// //StreamWriter writer = new StreamWriter(request.GetRequestStream());
// //writer.Write(DataToPost);
// //writer.Close();

//             HttpWebResponse res =(HttpWebResponse)req.GetResponse();
//             Stream Stream = res.GetResponseStream();  
//             StreamReader sr = new System.IO.StreamReader(Stream);
//             Boats Out =(Boats) sr.ReadToEnd();
//             sr.Close();
//             res.Close();
//var mdl=from c in db.DayShedules select new DayShedules(){c,c.} 

//var sss=from c in  db.DayShedules  group c by c.TimeStart.ToString().Substring(0,10) into g  group g by g; 

var sss=from c in db.DayShedules
        group c by c.TimeStart.ToString().Substring(0,10) into newGroup1 select newGroup1;
        // from newGroup2 in
        //     (from c in newGroup1
        //      group c by c.BoatId)
        // group newGroup2 by newGroup1.Key;




foreach(var item in sss){
Debug.WriteLine(item.Key);
    foreach(var item1 in item){

//         foreach (var item2 in item1)
//         {

// string str=item2.BoatName;


//         }
    }
}

//var bbb=sss..GroupBy(c=>c)

// foreach(var col in sss){
// string ss="";

// }

            return View(sss);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
