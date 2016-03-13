using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        [HandleError(ExceptionType = typeof(SqlException), View = "ErrorSql")]
        public ActionResult ErrorTest(String e)
        {
            if (e == "1")
            {
                throw new ArgumentException("Error 1");
            }

            if (e == "2")
            {
                throw new Exception("Error 2");
            }
            return Content("No Error");
        }

        public ActionResult Razortest()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5 };

            return PartialView(data);
        }
    }
}