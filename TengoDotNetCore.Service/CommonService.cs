using JiebaNet.Segmenter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class CommonService : BaseService {
        public CommonService(TengoDbContext db) : base(db) { }

        //public async Task<Dictionary<string, object>> GetHomeIndexViewModel() {
        //    var dic = new Dictionary<string, object>();
        //    dic["Banners"] = await db.Article
        //                            .Where(p => p.ArticleType_Id == 4)
        //                            .Take(10)
        //                            .ToListAsync();
        //    dic["Goods"] = await db.Goods
        //                            .Where(p => p.Status == 1)
        //                            .OrderBy(p => Guid.NewGuid())
        //                            .Take(60)
        //                            .ToListAsync();
        //    return dic;
        //}

        //public void TestFenCi() {
        //    var segmenter = new JiebaSegmenter();
        //    var segments = segmenter.Cut("我来到北京清华大学", cutAll: true);
        //    Console.WriteLine("【全模式】：{0}", string.Join("/ ", segments));

        //    segments = segmenter.Cut("我来到北京清华大学");  // 默认为精确模式
        //    Console.WriteLine("【精确模式】：{0}", string.Join("/ ", segments));

        //    segments = segmenter.Cut("他来到了网易杭研大厦");  // 默认为精确模式，同时也使用HMM模型
        //    Console.WriteLine("【新词识别】：{0}", string.Join("/ ", segments));

        //    segments = segmenter.CutForSearch("小明硕士毕业于中国科学院计算所，后在日本京都大学深造"); // 搜索引擎模式
        //    Console.WriteLine("【搜索引擎模式】：{0}", string.Join("/ ", segments));

        //    segments = segmenter.Cut("结过婚的和尚未结过婚的");
        //    Console.WriteLine("【歧义消除】：{0}", string.Join("/ ", segments));
        //}
    }
}
