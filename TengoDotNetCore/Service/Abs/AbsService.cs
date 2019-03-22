using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service.Abs {
    public abstract class AbsService {

        /// <summary>
        /// dbcontext对象
        /// </summary>
        protected readonly TengoDbContext db;

        public AbsService(TengoDbContext db) {
            this.db = db;
        }

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

        /// <summary>
        /// 响应错误异常
        /// </summary>
        /// <param name="e">报错对象</param>
        /// <returns></returns>
        public JsonResultObj Error(Exception e) {
            return new JsonResultObj(-999, e.Message, e.InnerException);
        }

        #region 公用方法 为了避免Service之间互相依赖，因此只能把一些公用的方法放到基础Service类里面了
        /// <summary>
        /// 通过一个父结点ID获取当前结点的所有祖先结点
        /// </summary>
        /// <param name="curParID"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetParentCategorys(int curParID) {
            var listPars = new List<Category>();
            while (curParID > 0) {
                var c = await db.Category.ToAsyncEnumerable().FirstOrDefault(p => p.ID == curParID);
                if (c == null) { break; }//如果父类为null的话，则直接退出
                listPars.Add(c);
                //更新当前父ID，以备后面继续遍历
                curParID = c.ParID;
            }
            return listPars;
        }
        #endregion
    }
}
