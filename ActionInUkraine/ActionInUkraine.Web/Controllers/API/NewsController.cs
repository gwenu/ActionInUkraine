using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System.Collections.Generic;
using System.Web.Http;

namespace ActionInUkraine.Web.Controllers.API
{
    public class NewsController : BaseApiController
    {
        public NewsController()
            : base(null)
        {
        }
        // GET api/news
        public IEnumerable<Article> Get()
        {
            var news = m_Repository.GetArticles();
            return news;
        }

        // GET api/news/5
        public Article Get(int id)
        {
            var article = m_Repository.GetArticle(id);
            return article;
        }

        // POST api/news
        public void Post([FromBody]Article value)
        {

        }

        // PUT api/news/5
        public void Put(int id, [FromBody]Article value)
        {
        }

        // DELETE api/news/5
        public void Delete(int id)
        {
        }
    }
}