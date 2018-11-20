using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HydroApp.Models;
using System.Net;
using System.IO;



namespace HydroApp.Controllers
{
    public class BoatController : Controller
    {



        public IActionResult Index()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/boat/1");
            //WebRequest req = WebRequest.Create("http://localhost:5000/api/boat/");
            req.Method = "POST";
            //req.Credentials = new NetworkCredential(username, password);
            //req.ContentLength = sentData.Length;
            //Stream sendStream = req.GetRequestStream();

            //request.ContentLength = DataToPost.Length;
//request.ContentType = "application/x-www-form-urlencoded";
//StreamWriter writer = new StreamWriter(request.GetRequestStream());
//writer.Write(DataToPost);
//writer.Close();

            HttpWebResponse res =(HttpWebResponse)req.GetResponse();
            Stream Stream = res.GetResponseStream();  
            StreamReader sr = new System.IO.StreamReader(Stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            res.Close();

            return View();
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
