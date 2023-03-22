using Fashion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext _context;
        public SubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SubCategory subCategory)
        {
            var data = _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            var data =await _context.SubCategories.Include(c=>c.Category).ToListAsync();
            return data;
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            var data =await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }

        public IEnumerable<SubCategory> SubCategories() => _context.SubCategories;
        

        public async Task<SubCategory> UpdateAsync(SubCategory newSubcategory)
        {
            var data = _context.SubCategories.Update(newSubcategory);
            await _context.SaveChangesAsync();
            return newSubcategory;
        }
    }
}
