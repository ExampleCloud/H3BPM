using OThinker.H3.Example.SSO.NetWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OThinker.H3.Example.SSO.NetWebSite.Controllers
{
    /// <summary>
    /// 模拟登陆中心的控制器。
    /// 这个是属于验证中心的控制器。实际应该存在于H3BPM项目中。
    /// 这里方便讲解所以放到了SSODemo中。
    /// </summary>
    public class SSOLoginController : Controller
    {
        /// <summary>
        /// 验证服务器的Session_Name
        /// </summary>
        private const string User_Seesion = "H3USER_SESSION";

        /// <summary>
        /// 验证服务器的编码
        /// </summary>
        private const string SystemCode = "H3";

        /// <summary>
        /// 验证服务器的密钥
        /// </summary>
        private const string Secret = "h3bpm";


        private H3SSOService.SSOServiceSoapClient _client = null;
        /// <summary>
        /// SSOService 客户端
        /// </summary>
        private H3SSOService.SSOServiceSoapClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new H3SSOService.SSOServiceSoapClient();
                }
                return _client;
            }
        }

        public ActionResult Index(SSOUser user)
        {
            //访问验证中心，如果已经验证过，则直接跳转到请求验证的系统地址。
            string redirectUrl = GetSystemUrl(user.TargetSystemCode, user.RedirectUrl);
            if (string.IsNullOrEmpty(redirectUrl))
            {
                return View(user);
            }
            else
            {
                return new RedirectResult(redirectUrl);
            }
        }

        public ActionResult Login(SSOUser user)
        {
            ValidateUser(user.UserCode, user.Password);
            string redirectUrl = GetSystemUrl(user.TargetSystemCode, user.RedirectUrl);
            if (string.IsNullOrEmpty(redirectUrl))
            {
                return View();
            }
            else
            {
                return new RedirectResult(redirectUrl);
            }
        }

        /// <summary>
        /// 调用SSO服务，统一入口验证
        /// </summary>
        private void ValidateUser(string userCode, string password)
        {
            bool result = false;
            result = client.ValidateUser(SystemCode, Secret, userCode, password);
            //用户验证成功，更新验证服务的用户Session状态
            if (result)
            {
                Session[User_Seesion] = userCode;
            }
        }

        /// <summary>
        /// 获取跳转地址
        /// </summary>
        /// <param name="targetSystemCode">需要登陆的系统Code，从H3BPM管理中心，请求服务的系统的编码</param>
        /// <param name="redictUrl">需要登陆的系统处理Token的地址，在自己的系统中解析Token，获取UserCode并处理自己的登陆逻辑</param>
        /// <returns>包含加密Token的跳转地址</returns>
        private string GetSystemUrl(string targetSystemCode, string redictUrl)
        {
            string result = string.Empty;
            //已经存在验证信息，调用SSOService 获取跳转地址。
            if (Session[User_Seesion] != null)
            {
                string userCode = Session[User_Seesion] + string.Empty;
                result = client.SSOSystemUrl(SystemCode, Secret, userCode, targetSystemCode, redictUrl);
            }
            return result;
        }
    }
}