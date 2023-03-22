using Fashion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fashion.Data.Services
{
    public interface ISubSubCategoryService
    {
        Task<IEnumerable<SubSubCategory>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(SubSubCategory subSubCategory);
        Task<SubSubCategory> UpdateAsync(SubSubCategory newSubSubcategory);
        Task<SubSubCategory> GetByIdAsync(int id);
        IEnumerable<SubSubCategory> SubSubCategories();
    }
}
