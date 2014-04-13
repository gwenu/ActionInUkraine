using ActionInUkraine.Entity;
using System.Collections.Generic;

namespace ActionInUkraine.Common
{
    public interface IRepository
    {
        List<string> GetOthers();
        List<string> GetCategories();
        IEnumerable<Idea> GetIdeas();
        // IEnumerable<Comment> GetComments();
        IEnumerable<NewsItem> GetNews();
        //IEnumerable<Blog> GetBlogs();
        List<string> GetBlogsLinks();
        Idea GetIdea(int id);
        NewsItem GetNewsItem(int id);
        void AddIdea(Idea value);
        void UpdateIdea(int id, Idea value);
        void DeleteIdea(int id);
        IEnumerable<UserProfile> GetUsers();
    }
}