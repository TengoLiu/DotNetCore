using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service.Abs {
    public abstract class AbsService {

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <returns></returns>
        public JsonResultObj Success(string msg) {
            return new JsonResultObj(1000, msg);
        }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="data">响应数据</param>
        /// <returns></returns>
        public JsonResultObj Success(string msg, object data) {
            return new JsonResultObj(1000, msg, data);

        }


        /// <summary>
        /// 响应报错异常
        /// </summary>
        /// <param name="status">错误状态代码</param>
        /// <param name="msg">提示消息</param>
        /// <param name="data">响应数据</param>
        /// <returns></returns>
        public JsonResultObj Error(string msg = "", object data = null) {
            return new JsonResultObj(-999, msg, data);

        }

        /// <summary>
        /// 响应报错异常
        /// </summary>
        /// <param name="status">错误状态代码</param>
        /// <param name="msg">提示消息</param>
        /// <param name="data">响应数据</param>
        /// <returns></returns>
        public JsonResultObj Error(int status, string msg = "", object data = null) {
            return new JsonResultObj(status, msg, data);

        }
    }
}
