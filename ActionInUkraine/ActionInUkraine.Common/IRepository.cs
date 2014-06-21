using ActionInUkraine.Entity;
using System.Collections.Generic;

namespace ActionInUkraine.Common
{
    public interface IRepository
    {
        List<string> GetOthers();
        IEnumerable<Category> GetCategories();
        IEnumerable<Idea> GetIdeas();
        // IEnumerable<Comment> GetComments();
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> GetIdeaArticles(int id);
        //IEnumerable<Blog> GetBlogs();
        List<string> GetBlogsLinks();
        Idea GetIdea(int id);
        Article GetArticle(int id);
        void AddIdea(Idea value);
        void UpdateIdea(int id, Idea value);
        void DeleteIdea(int id);
        IEnumerable<UserProfile> GetUsers();
    }
}