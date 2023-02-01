namespace Services.IServices
{
    public interface IService<TEntity> where TEntity : class
    {
        public Task<TEntity> GetById(int id);
        public Task<List<TEntity>> GetAll();
    }
}
