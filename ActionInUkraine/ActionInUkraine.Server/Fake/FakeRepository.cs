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
        public List<string> GetCategories()
        {
            var categories = new List<string>
                {
                    "культура",
                    "соціальний",
                    "екологія",
                    "освіта",
                    "технології",
                     "соціальне підприємництво",
                    "інше"
                };
            return categories;
        }
        //idea
        public IEnumerable<Idea> GetIdeas()
        {
            UsersContext context = new UsersContext();
            return context.Ideas;
        }
        public Idea GetIdea(int id)
        {
            UsersContext context = new UsersContext();
            return context.Ideas.First(a => a.IdeaID == id);

        }
        public void AddIdea(Idea value)
        {
            using (var _db = new UsersContext())
            {
                _db.Ideas.Add(value);
                _db.SaveChanges();
            }

        }
        public void UpdateIdea(int id, Idea value)
        {
        }
        public void DeleteIdea(int id)
        {
        }
        // news
        public IEnumerable<NewsItem> GetNews()
        {
            return null; ;
        }
        public NewsItem GetNewsItem(int id)
        {
            return null;
        }
        public void AddNewsItem(NewsItem value)
        {
        }
        public void UpdateNewsItem(int id, NewsItem value)
        {
        }
        public void DeleteNewsItem(int id)
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