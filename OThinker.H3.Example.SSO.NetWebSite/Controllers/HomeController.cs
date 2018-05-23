using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OThinker.H3.Example.SSO.NetWebSite.Services;
using OThinker.H3.Example.SSO.NetWebSite.Models;

namespace OThinker.H3.Example.SSO.NetWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session[SessionUtility.GetUserSession()] == null)
            {
                return new  RedirectResult("/Login/index");
            }
            else {
                User user =(User) Session[SessionUtility.GetUserSession()];

                return View(user);

            }
        }

    }
}