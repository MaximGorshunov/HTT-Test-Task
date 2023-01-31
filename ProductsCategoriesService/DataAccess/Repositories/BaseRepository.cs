using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Services")]
[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace DataAccess.Repositories
{
    internal abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProductsCategoriesDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(ProductsCategoriesDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public abstract Task<TEntity> GetById(int id);
        public abstract IQueryable<TEntity> GetAll();
    }
}
