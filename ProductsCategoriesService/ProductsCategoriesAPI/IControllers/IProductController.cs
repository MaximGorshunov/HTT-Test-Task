using ProductsCategoriesAPI.IModels;

namespace ProductsCategoriesAPI.IControllers
{
    public interface IProductController
    {
        Task<IApiResponse<List<IProductResponse>>> ProductsListWithCatigory(); 
    }
}
