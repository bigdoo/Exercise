using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            if (checkedLogin(login.Email,login.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private bool checkedLogin(string username, string password)
        {
             return (
                username == "doggy.huang@gmail.com" &&
                password == "123"
             );
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}