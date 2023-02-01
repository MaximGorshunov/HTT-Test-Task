using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Exeptions;
using Services.IServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace Services.Services
{
    internal class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository) : base(repository) { }

        public virtual async Task<Product> GetById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch(SqlException ex)
            {
                var message = "An error occurred while getting product by id";
                throw new BuisnessExeption(message, ex);
            }
        }

        public virtual async Task<List<Product>> GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return await result.ToListAsync();
            }
            catch(SqlException ex)
            {
                var message = "An error occurred while getting products list";
                throw new BuisnessExeption(message, ex);
            }
        }

        public virtual async Task<List<Product>> GetAllIncludeCategory()
        {
            try
            {
                var result = _repository.GetAll().Include(x => x.Category);
                return await result.ToListAsync();
            }
            catch(SqlException ex)
            {
                var message = "An error occurred while getting product list";
                throw new BuisnessExeption(message, ex);
            }
        }
    }
}
