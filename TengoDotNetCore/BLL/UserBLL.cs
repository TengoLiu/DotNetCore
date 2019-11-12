using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.BLL {
    public class UserBLL : BaseBLL {
        public UserBLL(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Insert(User model) {
            try {
                //由于登录的时候既可以使用账号也可以使用手机号，那么账号和手机号肯定不能重复
                var existsUser = await db.User.FirstOrDefaultAsync(p => p.NickName == model.NickName.Trim()
                || p.Phone == model.Phone.Trim() || p.Phone == model.Account.Trim()
                || p.Account == model.Account.Trim() || p.Account == model.Phone.Trim());
                if (existsUser != null) {
                    if (existsUser.NickName == model.NickName.Trim()) {
                        return JsonResultError("您填写的昵称已被占用，请重新填写！");
                    }
                    else if (existsUser.Phone == model.Phone.Trim() || existsUser.Phone == model.Account.Trim()) {
                        return JsonResultError("您填写的手机号码已被占用，请重新填写！");
                    }
                    else if (existsUser.Account == model.Account.Trim() || existsUser.Account == model.Phone.Trim()) {
                        return JsonResultError("您填写的账号已被占用，请重新填写！");
                    }
                }
                db.User.Add(model);
                await db.SaveChangesAsync();
                return JsonResultSuccess("注册成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Update(User model) {
            try {
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Phone).IsModified = true;
                db.Entry(model).Property(p => p.UpdateTime).IsModified = true;
                await db.SaveChangesAsync();
                return JsonResultSuccess("更新成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Delete(int? id) {
            if (id == null) {
                return JsonResultSuccess("删除成功！");
            }
            var model = await db.User.SingleOrDefaultAsync(p => p.Id == id);
            if (model != null) {
                db.User.Remove(model);
                await db.SaveChangesAsync();
            }
            return JsonResultSuccess("删除成功！");
        }

        public async Task<JsonResultObj> Login(string account, string password, string ip) {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password)) {
                return JsonResultError("账号和密码不能为空！");
            }
            var user = await db.User.FirstOrDefaultAsync(p => p.Phone == account || p.Account == account);
            if (user == null) {
                return JsonResultError("对不起，该用户不存在，请检查输入的账号和密码是否有误！");
            }
            else {
                if (user.Password == password) {
                    user.LastIP = ip;
                    user.LastTime = DateTime.Now;
                    db.SaveChanges();

                    //返回响应的时候要把密码置掉，免得被人知道
                    user.Password = string.Empty;
                    return JsonResultSuccess("success", user);
                }
                else {
                    return JsonResultError("对不起，您输入的密码有误！");
                }
            }
        }
    }
}
