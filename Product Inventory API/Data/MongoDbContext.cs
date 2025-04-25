using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductInventoryAPI.Models;
using System;

namespace ProductInventoryAPI.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var connectionString = options.Value.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString", "MongoDB connection string cannot be null or empty.");
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("product");
    }
}
