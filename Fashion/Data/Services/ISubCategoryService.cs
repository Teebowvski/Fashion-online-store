using Fashion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(SubCategory subCategory);
        Task<SubCategory> UpdateAsync(SubCategory newSubcategory);
        Task<SubCategory> GetByIdAsync(int id);
        IEnumerable<SubCategory> SubCategories();
    }
}
