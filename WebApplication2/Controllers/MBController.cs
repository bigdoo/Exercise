using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
         public ActionResult Index(String Name,DateTime Birthday)
         {
             return Content(Name + "" + Birthday);
         }

        /* [HttpPost]
         public ActionResult Index(FormCollection form)
         {
             return Content(form["Name"] + "" + form["Birthday"]);
         }*/

         /*[HttpPost]//不建議舊寫法
         public ActionResult Index(int a)
         {
            return Content(Request.Form["Name"] + " " + Request.Form["Birthday"]);
        }*/
    }
}