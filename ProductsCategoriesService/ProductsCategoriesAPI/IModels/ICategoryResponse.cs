namespace ProductsCategoriesAPI.IModels
{
    public interface ICategoryResponse
    {
        public int Id { get; }
        public string Name { get; }
        public List<IProductResponse> Products { get; }
    }
}
