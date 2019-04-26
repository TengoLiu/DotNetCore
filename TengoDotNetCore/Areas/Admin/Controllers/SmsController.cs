using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class SmsController : BaseController {

        private readonly SmsService service;
        public SmsController(SmsService service) {
            this.service = service;
        }
        #region Index 发送列表
        public async Task<IActionResult> Index(PageInfo pageInfo, DateTime? datemin = null, DateTime? datemax = null, string keyword = null) {
            ViewBag.Keyword = keyword;
            ViewBag.datemin = ((DateTime)datemin).ToString("yyyy-MM-dd");
            ViewBag.datemax = ((DateTime)datemax).ToString("yyyy-MM-dd");
            ViewData.Model = await service.GetSmsLogs(pageInfo, datemin, datemax, keyword);
            return View();
        }
        #endregion
    }
}