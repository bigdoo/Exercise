using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [共用ViewBagMessage]
        [紀錄Action的執行時間Attribute]
        public ActionResult About()
        {
            return View();
        }
        [共用ViewBagMessage]
        [紀錄Action的執行時間Attribute]
 
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}