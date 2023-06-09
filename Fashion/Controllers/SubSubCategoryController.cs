﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fashion.Data;
using Fashion.Models;

namespace Fashion.Controllers
{
    public class SubSubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubSubCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubSubCategory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubSubCategories.Include(s => s.SubCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubSubCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.SubSubCategories
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subSubCategory == null)
            {
                return NotFound();
            }

            return View(subSubCategory);
        }

        // GET: SubSubCategory/Create
        public IActionResult Create()
        {
            ViewData["SubCategory"] = new SelectList(_context.SubCategories, "Id", "Name");
            return View();
        }

        // POST: SubSubCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubSubCatName,SubCategoryID")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategory"] = new SelectList(_context.SubCategories, "Id", "Name", subSubCategory.SubSubCatName);
            return View(subSubCategory);
        }

        // GET: SubSubCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.SubSubCategories.FindAsync(id);
            if (subSubCategory == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "Id", "Id", subSubCategory.SubCategoryID);
            return View(subSubCategory);
        }

        // POST: SubSubCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubSubCatName,SubCategoryID")] SubSubCategory subSubCategory)
        {
            if (id != subSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubSubCategoryExists(subSubCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "Id", "Id", subSubCategory.SubCategoryID);
            return View(subSubCategory);
        }

        // GET: SubSubCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.SubSubCategories
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subSubCategory == null)
            {
                return NotFound();
            }

            return View(subSubCategory);
        }

        // POST: SubSubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subSubCategory = await _context.SubSubCategories.FindAsync(id);
            _context.SubSubCategories.Remove(subSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubSubCategoryExists(int id)
        {
            return _context.SubSubCategories.Any(e => e.Id == id);
        }
    }
}
