using ActionInUkraine.Common;
using ActionInUkraine.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ActionInUkraine.Server.Fake
{
    public class FakeRepository : IRepository
    {
        // 
        public List<string> GetOthers()
        {

            XDocument xml = null;
            List<string> others = null;
            try
            {
                string path = HttpContext.Current.Server.MapPath("/App_Data/othersList.xml");
                xml = XDocument.Load(path);
                others = xml.Root.Elements("other")
                    .Select(element => element.Value)
                    .ToList();
            }
            catch (DirectoryNotFoundException dirEx)
            {
                // Let the user know that the directory did not exist.
                Console.WriteLine("Directory not found: " + dirEx.Message);
            }
            catch (NullReferenceException nullRef)
            {
                // Let the user know that the directory did not exist.
                Console.WriteLine("NullReferenceException: " + nullRef.Message);
            }



            return others;
        }

        public List<string> GetBlogsLinks()
        {
            var feeds = new List<string>
            {
                "http://rss.news.yahoo.com/rss/entertainment",
                "http://pinterest.com/rollingstones50/feed.rss",
                "http://rollingstonesofficial.tumblr.com/rss"
            };
            return feeds;
        }

        public IEnumerable<Category> GetCategories()
        {
            using (var context = new UsersContext())
                return context.Categories;
        }

        //idea
        public IEnumerable<Idea> GetIdeas()
        {
            using (var context = new UsersContext())
                return context.Ideas;
        }

        public Idea GetIdea(int id)
        {
            using (var context = new UsersContext())
                return context.Ideas.Include("Category").FirstOrDefault(a => a.IdeaID == id);
        }

        public void AddIdea(Idea value)
        {
            using (var context = new UsersContext())
            {
                context.Ideas.Add(value);
                context.SaveChanges();
            }
        }

        public void UpdateIdea(int id, Idea value)
        {
        }

        public void DeleteIdea(int id)
        {
        }

        // news
        public IEnumerable<Article> GetArticles()
        {
            using (var context = new UsersContext())
                return context.Articles;
        }

        public IEnumerable<Article> GetIdeaArticles(int id)
        {
            using (var context = new UsersContext())
                return context.Articles.Where(x => x.IdeaId == id);
        }

        public Article GetArticle(int id)
        {
            using (var context = new UsersContext())
                return context.Articles.FirstOrDefault(x => x.ArticleId == id);
        }

        public void AddArticle(Article value)
        {
        }

        public void UpdateArticle(int id, Article value)
        {
        }

        public void DeleteArticle(int id)
        {
        }


        //public IEnumerable<Blog> GetBlogs()
        //{
        //    return blog_LIST;
        //}

        public IEnumerable<UserProfile> GetUsers()
        {
            return null;
        }

    }
}