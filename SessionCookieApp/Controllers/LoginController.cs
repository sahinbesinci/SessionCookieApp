using SessionCookieApp.DAL;
using SessionCookieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SessionCookieApp.Controllers
{
    public class LoginController : Controller
    {
        authenticationuserwithoutroleContext db = new authenticationuserwithoutroleContext();


        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Admin/Index");
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                if (db.users.Any(user => (user.Email == model.EMail && user.password == model.Password)))
                {
                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}