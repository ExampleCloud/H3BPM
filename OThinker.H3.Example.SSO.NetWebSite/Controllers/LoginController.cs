using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OThinker.H3.Example.SSO.NetWebSite.Models;
using OThinker.H3.Example.SSO.NetWebSite.Services;

namespace OThinker.H3.Example.SSO.NetWebSite.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 常量用户Code
        /// </summary>
        private const string UserCode = "admin";

        /// <summary>
        /// 常量用户密码
        /// </summary>
        private const string Password = "admin";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            if (user.UserCode == UserCode && user.Password == Password)
            {
                Session[SessionUtility.GetUserSession()] = user;
                return new RedirectResult("/Home/Index");
            }
            else {

                return View();
            }
      
        }
    }
}