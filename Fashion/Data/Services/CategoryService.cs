using Fashion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            var data =  _context.Categories.Add(category);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<Category> Categories() => _context.Categories.Include(c=>c.SubCategories);
        

        public async Task DeleteAsync(int id)
        {
            var data = _context.Categories.FirstOrDefault(x => x.Id == id);
                _context.Remove(data);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var data = await _context.Categories.ToListAsync();
            return data;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            return data;
        }

        public async Task<Category> UpdateAsync(Category newCategory)
        {
            var data = _context.Update(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;

        }
    }
}
