using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class SmsController : BaseController {

        #region Index 发送列表
        public async Task<IActionResult> Index([FromServices]TengoDbContext db, PageInfo pageInfo, DateTime? datemin = null, DateTime? datemax = null, string keyword = null) {
           
            ViewBag.Keyword = keyword;
            ViewBag.datemin = ((DateTime)datemin).ToString("yyyy-MM-dd");
            ViewBag.datemax = ((DateTime)datemax).ToString("yyyy-MM-dd");

            var query = db.SMSLog.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Mobile.Contains(keyword)
                                        || p.Content.Contains(keyword)
                                        || p.SendFor.Contains(keyword)
                                        || p.Platform.Contains(keyword));
            }

            if (datemin > new DateTime(1900, 1, 1)) {
                query = query.Where(p => p.AddTime >= datemin);
            }

            if (datemax > new DateTime(1900, 1, 1)) {
                var end = ((DateTime)datemax).AddDays(1);
                query = query.Where(p => p.AddTime <= end);
            }
           
            ViewData.Model = await db.GetPageListAsync(query, pageInfo);
            return View();
        }
        #endregion
    }
}