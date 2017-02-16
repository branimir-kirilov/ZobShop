using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.Services.Contracts
{
    public interface IProductService
    {
        Product CreateProduct(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType,
            byte[] imageBuffer);

        Product GetById(int id);

        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsByCategory(string categoryName);

        void EditProduct(Product product);

        void DeleteProduct(int productId);

        IEnumerable<Product> SearchProducts(string searchQuery);
    }
}
