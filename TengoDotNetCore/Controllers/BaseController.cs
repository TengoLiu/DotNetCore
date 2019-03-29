using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Common;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Controllers {
    public class BaseController : MyControllerBase {


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
    }
}