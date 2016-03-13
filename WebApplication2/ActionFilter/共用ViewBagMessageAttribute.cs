﻿using System;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class 共用ViewBagMessageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
            base.OnActionExecuting(filterContext);
        }
    }
}