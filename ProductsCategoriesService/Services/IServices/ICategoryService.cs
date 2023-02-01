using DataAccess.Entities;

namespace Services.IServices
{
    public interface ICategoryService : IService<Category>
    {
        Task<List<Category>> GetAllIncludeProducts();
        Task<List<Category>> GetAllIncludeProducts(List<int> categoriesId);
    }
}
