using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Common {
    public class Constant {

        #region 各种报错的提示文字
        /// <summary>
        /// 默认的报错信息
        /// </summary>
        public const string ERROR_DEFAULT = "系统繁忙，请稍后再试...";

        /// <summary>
        /// 提交的参数缺失
        /// </summary>
        public const string ERROR_PARAM_MISSED = "提交的参数缺失...";

        /// <summary>
        /// 提交的参数有误
        /// </summary>
        public const string ERROR_PARAM = "提交的参数有误...";

        /// <summary>
        /// 登录状态过期
        /// </summary>
        public const string ERROR_LOGIN_OVERTIME = "您的登录状态已过期，请重新登录...";

        /// <summary>
        /// 权限不足,需要权限才能继续操作
        /// </summary>
        public const string ERROR_PERMISSION_REQUIRE = "对不起，您没有相关的权限.";

        #endregion 

        #region 正则表达式
        /// <summary>
        /// 手机号的正则表达式
        /// </summary>
        public const string REGEX_PHONE = @"^[1][1,2,3,4,5,6,7,8,9][0-9]{9}$";

        /// <summary>
        /// 18位身份证正则
        /// </summary>
        public const string REGEX_IDCARD = @"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$";

        #endregion

        #region Session键名称
        /// <summary>
        /// 存储用户Session的名称
        /// </summary>
        public const string SESSION_USER = "SESSION_USER";

        /// <summary>
        /// 存储管理员对象的Session
        /// </summary>
        public const string SESSION_MANAGER = "SESSION_MANAGER";

        /// <summary>
        /// 图形验证码名称
        /// </summary>
        public const string SESSION_VERIFY_CODE = "SESSION_VERIFY_CODE";

        /*
         * 当获取短信验证码的时候，有两种情况，
         * 1.需要检验要发验证码的人是不是我们平台的用户，这种情况下，就需要检查用户是否存在
         *  
         * 2.不需要检验是不是我们平台的用户
         * 
         * 在这里，我把两种通道区分开了
         */
        /// <summary>
        /// 非平台用户手机验证码
        /// </summary>
        public const string SESSION_SMS_CODE = "SESSION_SMS_CODE";

        /// <summary>
        /// 非平台用户获取验证码的手机号
        /// </summary>
        public const string SESSION_USER_PHONE = "SESSION_USER_PHONE";

        /// <summary>
        /// 非平台用户上一次发送手机验证码的时间
        /// </summary>
        public const string SESSION_LAST_SMS_TIME = "SESSION_LAST_SMS_TIME";

        /// <summary>
        /// 平台用户上一次获取短信验证码的时间
        /// </summary>
        public const string SESSION_EXIST_USER_LAST_SMS_TIME = "SESSION_EXIST_USER_LAST_SMS_TIME";

        /// <summary>
        /// 平台用户获取短信验证码保存的账号
        /// </summary>
        public const string SESSION_EXIST_USER_ACCOUNT = "SESSION_EXIST_USER_ACCOUNT";

        /// <summary>
        /// 平台用户获取的短信验证码
        /// </summary>
        public const string SESSION_EXIST_USER_SMS_CODE = "SESSION_EXIST_USER_SMS_CODE";

        /// <summary>
        /// 是否是第一次注册的Flag，在注册成功之后，如果有这个flag则证明是刚注册，所以要显示密码
        /// </summary>
        public const string SESSION_REGISTER_FLAG = "SESSION_REGISTER_FLAG";

        /// <summary>
        /// 用户来源id
        /// </summary>
        public const string SESSION_SOURCE_ID = "SESSION_SOURCE_ID";
        #endregion

        #region Cookie键名称
        /// <summary>
        ///登录时记住的用户名
        /// </summary>
        public const string COOKIE_REMEMBER_USER_NAME = "COOKIE_REMEMBER_USER_NAME";

        /// <summary>
        /// 管理员记住的账号
        /// </summary>
        public const string COOKIE_REMEMBER_ADAC = "COOKIE_REMEMBER_ADAC";

        /// <summary>
        /// 管理员记住的密码
        /// </summary>
        public const string COOKIE_REMEMBER_ADPD = "COOKIE_REMEMBER_ADPD";

        #endregion

        /// <summary>
        /// 默认的DateTime时间
        /// </summary>
        public static readonly DateTime DEFAULT_DATETIME = new DateTime(1900, 1, 1);

        /// <summary>
        /// 默认头像的地址
        /// </summary>
        public const string DEFAULT_HEAD_PIC = "/upload/head_pics/default.png";

        /// <summary>
        /// 默认头像的地址
        /// </summary>
        public const string DEFAULT_PIC = "/img/default.jpg";
    }
}
