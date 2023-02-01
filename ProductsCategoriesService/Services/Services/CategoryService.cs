using Services.IServices;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Services.Exeptions;

[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace Services.Services
{
    internal class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository) { }

        public virtual async Task<Category> GetById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch (SqlException ex)
            {
                var message = "An error occurred while getting category by id";
                throw new BuisnessExeption(message, ex);
            }
        }

        public virtual async Task<List<Category>> GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return await result.ToListAsync();
            }
            catch (SqlException ex)
            {
                var message = "An error occurred while getting categories list";
                throw new BuisnessExeption(message, ex);
            }
        }

        public virtual async Task<List<Category>> GetAllIncludeProducts()
        {
            try
            {
                var result = _repository.GetAll().Include(x => x.Products);
                return await result.ToListAsync();
            }
            catch (SqlException ex)
            {
                var message = "An error occurred while getting categories list included products";
                throw new BuisnessExeption(message, ex); ;
            }
        }

        public virtual async Task<List<Category>> GetAllIncludeProducts(List<int> categoriesId)
        {
            try
            {
                var result = _repository.GetAll()
                    .Where(x => categoriesId.Contains(x.Id)).Include(x => x.Products);

                return await result.ToListAsync();
            }
            catch (SqlException ex)
            {
                var message = "An error occurred while getting categories list by ids";
                throw new BuisnessExeption(message, ex);
            }
        }
    }
}

