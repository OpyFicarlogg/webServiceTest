using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WsFirst.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titre { get; set; }

        public string Intertitre { get; set; }

        public string Body { get; set; }

        public string Author {get; set;}

    }
}