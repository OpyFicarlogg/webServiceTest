using WsFirst.Models;
using WsFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WsFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _ArticleService;

        public ArticlesController(ArticleService articleService)
        {
            _ArticleService = articleService;
        }

        [HttpGet]
        public ActionResult<List<Article>> Get() =>
            _ArticleService.Get();

        [HttpGet("{id:length(24)}", Name = "GetArticle")]
        public ActionResult<Article> Get(string id)
        {
            var article = _ArticleService.Get(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            _ArticleService.Create(article);

            return CreatedAtRoute("GetBook", new { id = article.Id.ToString() }, article);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Article articleIn)
        {
            var book = _ArticleService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _ArticleService.Update(id, articleIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var article = _ArticleService.Get(id);

            if (article == null)
            {
                return NotFound();
            }

            _ArticleService.Remove(article.Id);

            return NoContent();
        }
    }
}