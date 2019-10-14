using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class CategoryController : BaseController {

        public async Task<IActionResult> Index([FromServices]TengoDbContext db) {
            ViewData.Model = await db.Category.ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add([FromServices]TengoDbContext db) {
            ViewBag.Category = await db.Category.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromServices]CategoryService service, Category model) {
            if (ModelState.IsValid) {
                return Json(await service.Insert(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromServices]TengoDbContext db, int id = 0) {
            if (id <= 0) {
                return NotFound();
            }
            var model = await db.Category.FirstOrDefaultAsync(p => p.Id == id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.Category = await db.Category.ToListAsync();
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromServices]CategoryService service, Category model) {
            if (ModelState.IsValid) {
                return Json(await service.Update(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromServices]CategoryService service, int id = 0) {
            return Json(await service.Delete(id));
        }
    }
}