using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WsFirst.Models
{
    public class Book
    {
        // BsonId define id, and BsonRepresentation convert in string 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // allow to change the name of a column 
        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}