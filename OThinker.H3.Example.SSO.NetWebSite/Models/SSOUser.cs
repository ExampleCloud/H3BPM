using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OThinker.H3.Example.SSO.NetWebSite.Models
{
    /// <summary>
    /// 单点登陆用户
    /// </summary>
    public class SSOUser
    {

        /// <summary>
        /// 目标系统编码
        /// </summary>
        public string TargetSystemCode { get; set; }

        /// <summary>
        /// 跳转地址
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        [Display(Name = "用户名")]
        public string UserCode { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }


    }
}