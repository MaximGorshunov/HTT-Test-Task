namespace ProductsCategoriesAPI.IModels
{
    public interface IProductResponse
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        int Amount { get; }
        string CategoryName { get; }
    }
}
