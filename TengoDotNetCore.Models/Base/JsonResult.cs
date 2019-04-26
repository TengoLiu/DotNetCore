using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Models.Base {

    /// <summary>
    /// 响应消息对象
    /// </summary>
    public class JsonResultObj {
        /// <summary>
        /// 响应状态，规定1000为成功
        /// </summary>
        public int code = -999;
        /// <summary>
        /// 响应消息
        /// </summary>
        public string msg = string.Empty;
        /// <summary>
        /// 数据主体对象
        /// </summary>
        public object data;

        public JsonResultObj() {

        }

        public JsonResultObj(int code, string msg = "", object data = null) {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }
    }
}
