using System.Linq;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.BLL.Data {
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