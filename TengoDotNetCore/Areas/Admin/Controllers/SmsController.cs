using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class SmsController : BaseController {

        public SmsController(TengoDbContext db) : base(db) { }

        #region Index 发送列表
        public async Task<IActionResult> Index(PageInfo pageInfo, DateTime? datemin = null, DateTime? datemax = null, string keyword = null) {
            var query = db.SMSLog.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Mobile.Contains(keyword)
                                        || p.Content.Contains(keyword)
                                        || p.SendFor.Contains(keyword)
                                        || p.Platform.Contains(keyword));
                ViewBag.Keyword = keyword;
            }
            if (datemin > new DateTime(1900, 1, 1)) {
                query = query.Where(p => p.AddTime > datemin);
                ViewBag.datemin = ((DateTime)datemin).ToString("yyyy-MM-dd");
            }
            if (datemax > new DateTime(1900, 1, 1)) {
                var end = ((DateTime)datemax).AddDays(1);
                query = query.Where(p => p.AddTime < end);
                ViewBag.datemax = ((DateTime)datemax).ToString("yyyy-MM-dd");
            }
            ViewData.Model = await PageList<SMSLog>.CreateAsync(query.OrderByDescending(p => p.ID), pageInfo);
            return View();
        }
        #endregion
    }
}