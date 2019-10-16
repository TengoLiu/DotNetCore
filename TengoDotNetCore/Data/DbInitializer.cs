using System.Linq;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.BLL.Data {
    /// <summary>
    /// 数据库初始化类
    /// 说明：网站启动的时候对数据库的初始化操作。比如检查某些表是否为空，如果为空的话需要插入一些基础数据。
    /// 时间：2019年10月16日
    /// </summary>
    public static class DbInitializer {
     
        public static void Initialize(TengoDbContext db) {

            // 如果文章分类表为空的话，那么初始化数据
            if (db.ArticleType.Any()) {
                return;   // 如果已经有数据了的话，直接返回
            }

            db.ArticleType.Add(new ArticleType {
                TypeName = "首页轮播图"
            });

            db.ArticleType.Add(new ArticleType {
                TypeName = "新闻资讯"
            });

            db.ArticleType.Add(new ArticleType {
                TypeName = "体育赛事"
            });

            db.SaveChanges();
        }
    }
}