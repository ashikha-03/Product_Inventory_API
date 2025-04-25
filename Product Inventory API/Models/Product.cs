using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductInventoryAPI.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; } 

        [BsonElement("ProductID")]
        public int ProductID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Brand")]
        public string Brand { get; set; }

        [BsonElement("ReleaseYear")]
        public int ReleaseYear { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
