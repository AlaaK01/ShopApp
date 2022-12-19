using MongoDB.Bson.Serialization.Attributes;

namespace ShopApp.shared.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("ProductId")]
        public string ProductId { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }


    }
}
