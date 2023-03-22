using Fashion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;
        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Brand brand)
        {
            var data = _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Brand> Brands() => _context.Brands;
        

        public async Task DeleteAsync(int id)
        {
            var data = _context.Brands.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            var data = await _context.Brands.ToListAsync();
            return data;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            var data = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Brand> UpdateAsync(int id,Brand newBrand)
        {
            var data = _context.Update(newBrand);
            await _context.SaveChangesAsync();
            return newBrand;
        }
    }
}
