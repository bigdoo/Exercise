using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);
            this.Redirect("/").ExecuteResult(this.ControllerContext);
        }
        // GET: Base
        protected ProductRepository repo = RepositoryHelper.GetProductRepository();
        public ActionResult Debug()
        {
            return Content("DEBUG");
        }
    }

}