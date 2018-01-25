using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Metot());
        }

        public List<Data> Metot()
        {
            List<Data> TempData = new List<Data>();
            int id = 1;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.haritamap.com/ilce/yenisehir-mersin");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();

            sr.Close();
            myResponse.Close();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class='yataylisteuclu']//li/a");

            foreach (var node in htmlNodes)
            {
                Data tempData = new Data
                {
                    Id = id,
                    Deger = node.InnerText.Replace(" Mahallesi", "").ToUpper()
                };
                id++;
                TempData.Add(tempData);
            }
            return TempData;

        }
    }
}