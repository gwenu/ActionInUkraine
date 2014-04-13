using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<NewsItem> Get()
        {
            var news = m_Repository.GetNews();
            return news;
        }

        // GET api/news/5
        public NewsItem Get(int id)
        {
            var NewsItem = m_Repository.GetNewsItem(id);
            return NewsItem;
        }

        // POST api/news
        public void Post([FromBody]NewsItem value)
        {

        }

        // PUT api/news/5
        public void Put(int id, [FromBody]NewsItem value)
        {
        }

        // DELETE api/news/5
        public void Delete(int id)
        {
        }
    }
}