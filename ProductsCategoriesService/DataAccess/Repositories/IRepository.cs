using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Services")]
[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace DataAccess.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetAll();
    }
}
