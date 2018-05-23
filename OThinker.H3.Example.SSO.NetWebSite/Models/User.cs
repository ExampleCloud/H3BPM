using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OThinker.H3.Example.SSO.NetWebSite.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

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