using Fashion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task AddAsync(Brand brand);
        Task DeleteAsync(int id);
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> UpdateAsync(int id,Brand newBrand);
        IEnumerable<Brand> Brands();
    }
}
