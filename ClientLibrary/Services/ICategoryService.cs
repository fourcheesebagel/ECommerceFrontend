using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;
using ClientLibrary.Models;

namespace ClientLibrary.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId);
    }
}
