using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Rema1000API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategory(int id);

        Task<bool> PutCategory(int id, Category category);

        Task<Category> PostCategory(Category category);

        Task DeleteCategory(int id);

        bool CategoryExists(int id);
    }
}