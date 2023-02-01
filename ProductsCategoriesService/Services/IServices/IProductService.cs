using DataAccess.Entities;

namespace Services.IServices
{
    public interface IProductService : IService<Product>
    {
        Task<List<Product>> GetAllIncludeCategory();
    }
}
