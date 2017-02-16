using SessionCookieApp.DAL;
using SessionCookieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionCookieApp.Controllers
{
    [_SessionControl]
    public class AdminController : Controller
    {
        authenticationuserwithoutroleContext db = new authenticationuserwithoutroleContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }
    }
}