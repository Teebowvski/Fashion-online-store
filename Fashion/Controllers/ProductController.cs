using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fashion.Data;
using Fashion.Models;
using Fashion.Data.Services;
using Fashion.ViewModels;

namespace Fashion.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryservice;
        private readonly ISubSubCategoryService _subSubCategoryService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService service, ICategoryService categoryService,ISubCategoryService subCategoryservice,ISubSubCategoryService subSubCategoryService, IBrandService brandService)
        {
            _service = service;
            _categoryService = categoryService;
            _subCategoryservice = subCategoryservice;
            _subSubCategoryService = subSubCategoryService;
            _brandService = brandService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "Name");
            ViewData["SubSubCategory"] = new SelectList(_subSubCategoryService.SubSubCategories(), "Id", "Id");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl,ImageUrl1,ImageUrl2,ImageUrl3,Description,LongDescription,Price,IsPreferred,BrandId,SubSubCategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(product);

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "Name", product.BrandId);
            ViewData["SubSubCategory"] = new SelectList(_subSubCategoryService.SubSubCategories(), "Id", "Id", product.SubSubCategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var propertyDetails = await _service.GetByIdAsync(id);
            if (propertyDetails == null) return View("Not Found");

            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "Name");
            ViewData["SubSubCategoryId"] = new SelectList(_subSubCategoryService.SubSubCategories(), "Id", "Name");
            return View(propertyDetails);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl,ImageUrl1,ImageUrl2,ImageUrl3,Description,LongDescription,Price,IsPreferred,BrandId,SubSubCategoryId")] Product product)
        {
            var propertyDetails = await _service.GetByIdAsync(id);
            if (propertyDetails == null) return View("Not Found");
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "Name", product.BrandId);
            ViewData["SubSubCategoryId"] = new SelectList(_subSubCategoryService.SubSubCategories(), "Id", "Name", product.SubSubCategoryId);
            return View(propertyDetails);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<ViewResult> List(string category)
        {

            IEnumerable<Product> products;
            string _category = category;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                products = _service.Products().OrderBy(x => x.Id);
                currentCategory = "ALl Products";
            }
            else
            {
                if (string.Equals("Men", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _service.Products().Where(p => p.SubSubCategory.SubCategory.Category.Name.Equals("Men")).OrderBy(x => x.Name);
                }
                else
                {
                    products = _service.Products().Where(p => p.SubSubCategory.SubCategory.Category.Name.Equals("Women")).OrderBy(x => x.Name);
                }

                currentCategory = _category;
            }


            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory,
                Categories = _categoryService.Categories(),
                SubCategories = _subCategoryservice.SubCategories()

            };

            return View(productListViewModel);
        }

        private bool ProductExists(int id)
        {
            return _service.Products().Any(e => e.Id == id);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var data = await _service.GetByIdAsync(id);



            return View(data);
        }
        
    }
}
