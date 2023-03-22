using Fashion.Data;
using Fashion.Data.Services;
using Fashion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _service;
        private readonly ICategoryService _categoryService;
        public SubCategoryController(ISubCategoryService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: SubCategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: SubCategoryController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.Categories(), "Id", "Name");
            return View();
        }

        // POST: SubCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Description,CategoryId") ] SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categoryService.Categories(), "Id", "Name", subCategory.SubCatName);
                return View(subCategory);
            }
          await  _service.AddAsync(subCategory);
            return RedirectToAction(nameof(Index));

           
        }

        // GET: SubCategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
            
        }

        // POST: SubCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Description")]SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(subCategory);
            }
            await _service.UpdateAsync(subCategory);
            return RedirectToAction(nameof(Index));
        }

        // GET: SubCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await  _service.GetByIdAsync(id);
            return View(data);
        }

        // POST: SubCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var data = await _service.GetByIdAsync(id);
         await   _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
