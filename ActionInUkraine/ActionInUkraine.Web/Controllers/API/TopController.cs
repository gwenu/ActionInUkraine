using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System.Collections.Generic;
using System.Web.Http;

namespace ActionInUkraine.Web.Controllers.API
{
    public class TopController : BaseApiController
    {
        public TopController()
            : base(null)
        {
        }
        //[ActionName("comments")]
        // public IEnumerable<Comment> GetTopComments()
        // {
        //     var comments = m_Repository.GetComments();
        //     return comments;
        // }

        [ActionName("ideas")]
        public IEnumerable<Idea> GetTopIdeas()
        {
            var ideas = m_Repository.GetIdeas();
            return ideas;
        }
        [ActionName("news")]
        public IEnumerable<NewsItem> GetTopNews()
        {
            var news = m_Repository.GetNews();
            return news;
        }
        //[ActionName("blogs")]
        //public IEnumerable<Blog> GetTopBlogs()
        //{
        //    var blogs = m_Repository.GetBlogs();
        //    return blogs;
        //}
    }
}
