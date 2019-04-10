using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Common {
    /// <summary>
    /// 所有控制器基类统一继承本类，里面包含BLL工厂、数据库连接等等元素
    /// </summary>
    public class MyControllerBase : Controller {

        /// <summary>
        /// dbcontext对象
        /// </summary>
        protected readonly TengoDbContext db;

        public MyControllerBase(TengoDbContext db) {
            this.db = db;
        }

        #region Session相关
        protected bool EsistsSession(string key) {
            return string.IsNullOrWhiteSpace(HttpContext.Session.GetString(key));
        }

        /// <summary>
        /// 获取Session对象,
        /// 注意：只有存储的类型为引用类型的时候，才这么取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected T GetSession<T>(string key) {
            var value = HttpContext.Session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 设置Session,只有涉及到Model的时候才需要这样设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SetSession<T>(string key, T value) {
            HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }
        #endregion

        #region 事务相关方法
        /// <summary>
        /// 开启事务
        /// </summary>
        protected void TrnsactionBegin() {

        }

        /// <summary>
        /// 提交事务
        /// </summary>
        protected void TrnsactionCommit() {

        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        protected void TrnsactionRollback() {

        }
        #endregion

        #region 返回JSON相关的方法
        protected IActionResult JsonResult(JsonResultObj jsonObj) {
            return Json(jsonObj);
        }

        protected IActionResult JsonResultSuccess(string msg) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = null
            });
        }

        protected IActionResult JsonResultSuccess(string msg, object obj) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            });
        }

        protected IActionResult JsonResultError(Exception e) {
            return Json(new JsonResultObj {
                code = 999,
                msg = e.Message
            });
        }

        protected IActionResult JsonResultError(string msg) {
            return Json(new JsonResultObj {
                code = 999,
                msg = msg
            });
        }

        protected IActionResult JsonResultError(string msg, object obj) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            });
        }

        protected IActionResult JsonResultParamInvalid() {
            return Json(new JsonResultObj {
                code = 1001,
                msg = "您提交的参数缺失或者有误，请检查输入的信息是否完整。",
            });
        }
        #endregion
    }
}