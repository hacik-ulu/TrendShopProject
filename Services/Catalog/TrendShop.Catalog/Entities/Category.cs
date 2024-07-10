using MongoDB.Bson.Serialization.Attributes;

namespace TrendShop.Catalog.Entities
{
    // MongoDB doesn't have any relational database and ID's are kept by string.
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
