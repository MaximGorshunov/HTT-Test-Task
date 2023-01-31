using DataAccess.Entities;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Services")]
[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace DataAccess.Repositories
{
    internal class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ProductsCategoriesDbContext context) : base(context) { }

        public override async Task<Product> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public override IQueryable<Product> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
