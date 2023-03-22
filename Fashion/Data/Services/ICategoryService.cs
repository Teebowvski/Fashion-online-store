using Fashion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task DeleteAsync(int id);
       Task<Category> GetByIdAsync(int id);
        Task<Category> UpdateAsync(Category newCategory);
        IEnumerable<Category> Categories();
    }
}
