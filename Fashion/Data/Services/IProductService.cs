using Fashion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Product product);
        Task<Product> UpdateAsync(int id,Product newProduct);
            Task<Product> GetByIdAsync(int id);
        IEnumerable<Product> Products();
    }
}
