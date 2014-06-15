using ActionInUkraine.Entity;
using System;
using System.Data.Entity;
using ActionInUkraine.Web.Implementations.Authentication;

namespace ActionInUkraine.Web.Filters
{
    public class InitDB : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
            // if (!WebMatrix.WebData.WebSecurity.UserExists("kohut.mykola@gmail.com"))
            WebSecurity.CreateUserAndAccount("kohut.mykola@gmail.com", "111111", "Mykola", "Kohut", "male", DateTime.Now, false);
            WebSecurity.CreateUserAndAccount("mrsmithjr@mail.ru", "222222", "Тарас", "Романик", "male", DateTime.Now, false);

            CreateIdeas(context);
            context.SaveChanges();
        }

        private void CreateIdeas(UsersContext context)
        {
            context.Ideas.Add(new Idea { UserId = 1, IdeaID = 1, Title = "Великий проект", Category = "освіта", Description = "опис невеликий", Image = "/uploads/97a762ea-9156-4a2b-9b57-1141c7fc334c.gif" });
            context.Ideas.Add(new Idea { UserId = 1, IdeaID = 2, Title = "Великий проект 2", Category = "культура", Description = "опис невеликий2", Image = "/uploads/2a2081ca-d0c0-4961-94c9-1360b9a28875.jpg" });
        }
    }
}