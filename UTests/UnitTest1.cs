using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.IO;
using System.Diagnostics;

namespace UTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetApi()
        {
            using(WebClient wc=new WebClient()){
             using(Stream stream=wc.OpenRead("http://localhost:5000/api/boat/")){
                using (StreamReader reader = new StreamReader(stream))
                {
                        Debug.WriteLine(reader.ReadToEnd());
                }
             }
            }

        }
        [TestMethod]
        public void PostApi(){
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


        }
    }
}
