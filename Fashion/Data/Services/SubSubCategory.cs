using Fashion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public class SubSubCategoryService : ISubSubCategoryService
    {
        private readonly ApplicationDbContext _context;
        public SubSubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SubSubCategory subsubcategory)
        {
            var data = _context.SubSubCategories.Add(subsubcategory);
            await _context.SaveChangesAsync();
        }

        

        public async Task DeleteAsync(int id)
        {
            var data = _context.SubSubCategories.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<SubSubCategory>> GetAllAsync()
        {
            var data = await _context.SubSubCategories.Include(c=>c.SubCategory).ToListAsync();
            return data;
        }

        public async Task<SubSubCategory> GetByIdAsync(int id)
        {
            var data = await _context.SubSubCategories.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public IEnumerable<SubSubCategory> SubSubCategories() => _context.SubSubCategories;
        
        

        public async Task<SubSubCategory> UpdateAsync(SubSubCategory newSubSubCategory)
        {
            var data = _context.Update(newSubSubCategory);
            await _context.SaveChangesAsync();
            return newSubSubCategory;

        }

        
       
        
    }
}

