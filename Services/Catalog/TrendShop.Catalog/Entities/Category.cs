using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrendShop.Catalog.Entities
{
    // MongoDB doesn't have any relational database and ID's are kept by string.
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
