using System;
using System.ComponentModel.DataAnnotations;
using TengoDotNetCore.Common;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Models {

    public class User : BaseModel {

        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "请填写您的账号"), StringLength(20, MinimumLength = 6), Display(Name = "账号")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请填写您的密码"), StringLength(16, MinimumLength = 8), Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "请填写您的昵称"), StringLength(20, MinimumLength = 2), Display(Name = "昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(ErrorMessage = "请填写您的手机号码")
            ,RegularExpression(Constant.REGEX_PHONE, ErrorMessage = "请填写正确格式的手机号码..."), Display(Name = "手机号码")]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 注册来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 上次登录的IP
        /// </summary>
        public string LastIP { get; set; }

        /// <summary>
        /// 上次登录的时间
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegisterIP { get; set; }
    }
}
