using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TengoDotNetCore.Common.MyController {
    public class BaseController : Controller {

        #region Session相关
        /// <summary>
        /// 获取Session对象,
        /// 注意：只有存储的类型为引用类型的时候，才这么取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected T Get<T>(string key) {
            var value = HttpContext.Session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 设置Session,只有涉及到Model的时候才需要这样设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void Set<T>(string key, T value) {
            HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }
        #endregion

    }
}