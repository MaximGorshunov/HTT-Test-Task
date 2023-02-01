using DataAccess.Repositories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ProductsCategoriesAPI")]

namespace Services.Services
{
    internal abstract class BaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;

        protected BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
    }
}
