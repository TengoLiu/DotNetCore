using System;
using System.Collections.Generic;
using System.Text;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.DAL {

    public interface IUserDAL {

        /// <summary>
        /// 通过id获取用户
        /// </summary>
        /// <returns></returns>
        User GetUserById();

        /// <summary>
        /// 通过手机号获取用户
        /// </summary>
        /// <returns></returns>
        User GetUserByPhone();

        /// <summary>
        /// 添加一个用户，并且返回该用户在数据库表中的id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Insert(User user);

        /// <summary>
        /// 更新一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Update(User user);

        /// <summary>
        /// 删除一个用户，并且返回删除被影响的行数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        List<User> List();

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<User> GetPageList(int page, int pageSize);
    }
}
