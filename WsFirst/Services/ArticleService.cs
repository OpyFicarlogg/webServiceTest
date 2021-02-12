using WsFirst.Models;
using WsFirst.Models.Database;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WsFirst.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<Article> _articles;

        public ArticleService(IBookstoreDatabaseSettings settings)
        {
            //Récupération des informations dans le appsettings.json
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articles = database.GetCollection<Article>("Articles");
        }

        public List<Article> Get() =>
            _articles.Find(article => true).ToList();

        public Article Get(string id) =>
            _articles.Find<Article>(article => article.Id == id).FirstOrDefault();

        public Article Create(Article article)
        {
            _articles.InsertOne(article);
            return article;
        }

        public void Update(string id, Article articleIn) =>
            _articles.ReplaceOne(article => article.Id == id, articleIn);

        public void Remove(Article articleIn) =>
            _articles.DeleteOne(article => article.Id == articleIn.Id);

        public void Remove(string id) => 
            _articles.DeleteOne(article => article.Id == id);
    }
}