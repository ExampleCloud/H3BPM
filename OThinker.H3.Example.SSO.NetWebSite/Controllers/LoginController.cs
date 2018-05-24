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
        /// 常量用户Code，用于验证用户信息。
        /// 真实业务场景中，应该存在于实际业务库中。
        /// </summary>
        private const string UserCode = "administrator";

        /// <summary>
        /// 常量用户密码
        /// 真实业务场景中，应该存在于实际业务库中。
        /// </summary>
        private const string Password = "000000";

        /// <summary>
        /// SSODemo的单点登陆编码
        /// </summary>
        private const string SystemCode = "SSODemo";

        /// <summary>
        /// SSODemo的单点登陆密钥
        /// </summary>
        private const string Secret = "SSODemo";

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>登陆后的视图</returns>
        public ActionResult Login(User user)
        {
            if (user.UserCode == UserCode && user.Password == Password)
            {
                Session[SessionUtility.GetUserSession()] = user;
                return new RedirectResult("/Home/Index");
            }
            else
            {
                return View();
            }

        }

        /// <summary>
        /// 单点登陆回调的方法
        /// </summary>
        /// <param name="token">验证服务器生成的Token</param>
        /// <returns>登陆成功后的地址</returns>
        public ActionResult SSOLogin(string token)
        {

            H3SSOService.SSOServiceSoapClient client = new H3SSOService.SSOServiceSoapClient();

            string userCode = client.GetAuthenticationUser(SystemCode, Secret, token);
            if (userCode == UserCode)
            {
                //这里会在系统里处理自己的登陆逻辑
                Session[SessionUtility.GetUserSession()] = new User() {
                     UserCode=UserCode
                };
                return new RedirectResult("/Home/Index");
            }
            return null;
        }
    }
}