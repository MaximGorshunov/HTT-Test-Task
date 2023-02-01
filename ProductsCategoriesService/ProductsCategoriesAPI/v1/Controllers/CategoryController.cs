using Services.IServices;
using Microsoft.AspNetCore.Mvc;
using ProductsCategoriesAPI.IControllers;
using ProductsCategoriesAPI.IModels;
using ProductsCategoriesAPI.v1.Models;
using DataAccess.Entities;
using Services.Exeptions;

namespace ProductsCategoriesAPI.v1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : Controller, ICategoryController
    {
        protected readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("categories-list")]
        public virtual async Task<IApiResponse<List<ICategoryResponse>>> CategoriesList()
        {
            IApiResponse<List<ICategoryResponse>> response = new ApiResponse<List<ICategoryResponse>>();

            try
            {
                List<ICategoryResponse> categories = new List<ICategoryResponse>();

                var _categories = await _service.GetAll();

                foreach (var c in _categories)
                {
                    categories.Add(new CategoryResponse(c.Id, c.Name));
                }

                response.Data = categories;
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
                response.ErrorMessage = "Can't get list of categories";
                return response;
            }
        }

        [HttpGet("categories-products-list")]
        public virtual async Task<IApiResponse<List<ICategoryResponse>>> CategoriesProductsList()
        {
            IApiResponse<List<ICategoryResponse>> response = new ApiResponse<List<ICategoryResponse>>();

            try
            {
                List<ICategoryResponse> categories = new List<ICategoryResponse>();

                var _categories = await _service.GetAllIncludeProducts();

                foreach (var c in _categories)
                {
                    List<IProductResponse> products = new List<IProductResponse>();

                    foreach (var p in c.Products)
                    {
                        products.Add(new ProductResponse(p.Id, p.Name, p.Price, p.Amount));
                    }

                    categories.Add(new CategoryResponse(c.Id, c.Name, products));
                }

                response.Data = categories;
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
                response.ErrorMessage = "Can't get list of categories";
                return response;
            }
        }

        [HttpPost("categories-products-list")]
        public virtual async Task<IApiResponse<List<ICategoryResponse>>> CategoriesProductsList([FromBody] List<int> categoriesId)
        {
            IApiResponse<List<ICategoryResponse>> response = new ApiResponse<List<ICategoryResponse>>();

            try
            {
                List<ICategoryResponse> categories = new List<ICategoryResponse>();

                if (categoriesId == null)
                {
                    response.Status = 400;
                    response.ErrorMessage = "Invalid request model";
                    return response;
                }

                var _categories = await _service.GetAllIncludeProducts(categoriesId);

                foreach (var c in _categories)
                {
                    List<IProductResponse> products = new List<IProductResponse>();

                    foreach (var p in c.Products)
                    {
                        products.Add(new ProductResponse(p.Id, p.Name, p.Price, p.Amount));
                    }

                    categories.Add(new CategoryResponse(c.Id, c.Name, products));
                }

                response.Data = categories;
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
                response.ErrorMessage = "Can't get list of categories";
                return response;
            }
        }
    }
}
