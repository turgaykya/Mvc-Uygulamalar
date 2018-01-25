using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using PageExample.Models;

namespace PageExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int Page=1)
        {
            List<TempModel> tempData = new List<TempModel>();
            for (int i = 0; i < 20; i++)
            {
                TempModel temp = new TempModel()
                {
                    id = i,
                    Name = "Deneme" + i+1
                };
                tempData.Add(temp);
            }

            return View(tempData.ToPagedList(Page,4));
        }
    }
}