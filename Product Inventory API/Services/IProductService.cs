using ProductInventoryAPI.Models;
using System.Collections.Generic;

namespace ProductInventoryAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
