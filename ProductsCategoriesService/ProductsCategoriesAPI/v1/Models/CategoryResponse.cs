using ProductsCategoriesAPI.IModels;

namespace ProductsCategoriesAPI.v1.Models
{
    public class CategoryResponse : ICategoryResponse
    {
        protected int _id;
        protected string _name;
        protected List<IProductResponse> _products;

        public CategoryResponse(int id, string name)
        {
            _id = id;
            _name = name;
            _products = new List<IProductResponse>();
        }

        public CategoryResponse(int id, string name, List<IProductResponse> products)
        {
            _id = id;
            _name = name;
            _products = products;
        }

        /// <summary>
        /// Category id
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// List of product defined by this category
        /// </summary>
        public List<IProductResponse> Products { get { return _products; } }
    }
}