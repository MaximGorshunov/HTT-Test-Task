using DataAccess.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Services")]
[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace DataAccess.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ProductsCategoriesDbContext context) : base(context) { }

        public override async Task<Category> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public override IQueryable<Category> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}

