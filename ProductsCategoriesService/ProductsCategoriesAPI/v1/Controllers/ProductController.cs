using Microsoft.AspNetCore.Mvc;
using ProductsCategoriesAPI.IControllers;
using ProductsCategoriesAPI.IModels;
using ProductsCategoriesAPI.v1.Models;
using Services.Exeptions;
using Services.IServices;

namespace ProductsCategoriesAPI.v1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : Controller, IProductController
    {
        protected readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("products-list-with-category")]
        public virtual async Task<IApiResponse<List<IProductResponse>>> ProductsListWithCatigory()
        {
            IApiResponse<List<IProductResponse>> response = new ApiResponse<List<IProductResponse>>();

            try
            {
                List<IProductResponse> products = new List<IProductResponse>();

                var _products = await _service.GetAllIncludeCategory();

                foreach (var c in _products)
                {
                    products.Add(new ProductResponse(c.Id, c.Name, c.Price, c.Amount, c.Category.Name));
                }

                response.Data = products;
                response.Status = 200;
                return response;
            }
            catch(BuisnessExeption)
            {
                response.Status = 502;
                response.ErrorMessage = "An error occurred while getting data";
                return response;
            }
            catch(Exception)
            {
                response.Status = 500;
                response.ErrorMessage = "Can't get list of products";
                return response;
            }
        }
    }
}
