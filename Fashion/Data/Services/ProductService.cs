using Fashion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Product product)
        {
            var data = _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Product> Products() => _context.Products.Include(d=>d.SubSubCategory).Include(c=>c.SubSubCategory.SubCategory).Include(c=>c.SubSubCategory.SubCategory.Category);


        public async Task DeleteAsync(int id)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var data = await _context.Products.Include(c=>c.Brand).Include(c=>c.SubSubCategory.SubCategory).Include(c => c.SubSubCategory.SubCategory.Category).ToListAsync();
            return data;
        }

        

        

        public async Task<Product> UpdateAsync(int id,Product newProduct)
        {
            var data = _context.Update(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var data = await  _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        
        

        
    }
}
