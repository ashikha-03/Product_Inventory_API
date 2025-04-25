using MongoDB.Driver;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductInventoryAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(MongoDbContext dbContext)
        {
            _products = dbContext.Products;
        }

        // Create
        public void AddProduct(Product product)
        {
            _products.InsertOne(product);
        }

        // Read
        public List<Product> GetAllProducts()
        {
            return _products.Find(product => true).ToList();
        }

        public Product GetProductById(int id)
        {
            return _products.Find(product => product.ProductID == id).FirstOrDefault();
        }

        // Update
        public void UpdateProduct(int id, Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.ProductID, id);
            var update = Builders<Product>.Update
                .Set(p => p.Name, updatedProduct.Name)
                .Set(p => p.Brand, updatedProduct.Brand)
                .Set(p => p.ReleaseYear, updatedProduct.ReleaseYear)
                .Set(p => p.Price, updatedProduct.Price);

            _products.UpdateOne(filter, update);
        }

        // Delete
        public void DeleteProduct(int id)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.ProductID, id);
            _products.DeleteOne(filter);
        }
    }
}
