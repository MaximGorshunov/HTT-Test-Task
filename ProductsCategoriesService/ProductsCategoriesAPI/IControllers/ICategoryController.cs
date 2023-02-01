using ProductsCategoriesAPI.IModels;

namespace ProductsCategoriesAPI.IControllers
{
    public interface ICategoryController
    {
        Task<IApiResponse<List<ICategoryResponse>>> CategoriesList();
        Task<IApiResponse<List<ICategoryResponse>>> CategoriesProductsList();
    }
}
