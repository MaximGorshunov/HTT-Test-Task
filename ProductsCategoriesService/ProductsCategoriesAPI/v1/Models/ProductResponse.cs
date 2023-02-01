using ProductsCategoriesAPI.IModels;

namespace ProductsCategoriesAPI.v1.Models
{
    public class ProductResponse : IProductResponse
    {
        protected int _id;
        protected string _name;
        protected decimal _price;
        protected int _amount;
        protected string _categoryName;

        public ProductResponse(int id, string name, decimal price, int amount)
        {
            _id = id;
            _name = name;
            _price = price;
            _amount = amount;
            _categoryName = "";
        }

        public ProductResponse(int id, string name, decimal price, int amount, string categoryName)
        {
            _id = id;
            _name = name;
            _price = price;
            _amount = amount;
            _categoryName = categoryName;
        }

        /// <summary>
        /// Product id
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get { return _price; } }

        /// <summary>
        /// Amount of product
        /// </summary>
        public int Amount { get { return _amount; } }

        /// <summary>
        /// Name of category
        /// </summary>
        public string CategoryName { get { return _categoryName; } }
    }
}

