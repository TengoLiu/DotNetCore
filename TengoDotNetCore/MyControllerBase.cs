using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore {
    /// <summary>
    /// 所有控制器基类统一继承本类，里面包含BLL工厂、数据库连接等等元素
    /// </summary>
    public class MyControllerBase : Controller {

        #region 返回JSON相关的方法
        protected IActionResult MyJsonResult(JsonResultObj jsonObj) {
            return Json(jsonObj);
        }

        protected IActionResult MyJsonResultSuccess(string msg) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = null
            });
        }

        protected IActionResult MyJsonResultSuccess(string msg, object obj) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            });
        }

        protected IActionResult MyJsonResultError(Exception e) {
            return Json(new JsonResultObj {
                code = 999,
                msg = e.Message
            });
        }

        protected IActionResult MyJsonResultError(string msg) {
            return Json(new JsonResultObj {
                code = 999,
                msg = msg
            });
        }
        
        protected IActionResult MyJsonResultError(string msg, object obj) {
            return Json(new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            });
        }

        protected IActionResult MyJsonResultParamInvalid() {
            return Json(new JsonResultObj {
                code = 1001,
                msg = "您提交的参数缺失或者有误，请检查输入的信息是否完整。",
            });
        }
        #endregion
    }
}