using System.Data.Entity.Migrations;
using System.Web.Security;
using ActionInUkraine.Entity;
using System;
using System.Data.Entity;
using ActionInUkraine.Web.Implementations.Authentication;

namespace ActionInUkraine.Web.Filters
{
    public class InitDB : DropCreateDatabaseIfModelChanges<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");
            if (!Roles.RoleExists("Expert"))
                Roles.CreateRole("Expert");
            if (!Roles.RoleExists("User"))
                Roles.CreateRole("User");

            if (Membership.GetUser("admin@diya-ua.com") == null)
                WebSecurity.CreateUserAndAccount("admin@diya-ua.com", "admin123", "Аміністратор", "Initial", "male", DateTime.Now, false);
            if (Membership.GetUser("expert@diya-ua.com") == null)
                WebSecurity.CreateUserAndAccount("expert@diya-ua.com", "expert123", "Експерт", "Initial", "female", DateTime.Now, false);
            if (Membership.GetUser("user@diya-ua.com") == null)
                WebSecurity.CreateUserAndAccount("user@diya-ua.com", "user123", "Користувач", "Initial", "male", DateTime.Now, false);
            if (Membership.GetUser("kohut.mykola@gmail.com") == null)
                WebSecurity.CreateUserAndAccount("kohut.mykola@gmail.com", "111111", "Mykola", "Kohut", "male", DateTime.Now, false);
            if (Membership.GetUser("mrsmithjr@mail.ru") == null)
                WebSecurity.CreateUserAndAccount("mrsmithjr@mail.ru", "222222", "Тарас", "Романик", "male", DateTime.Now, false);
            
            if (!Roles.IsUserInRole("admin@diya-ua.com", "Admin"))
                Roles.AddUsersToRoles(new[] { "admin@diya-ua.com" }, new[] { "Admin", "Expert", "User" });
            if (!Roles.IsUserInRole("expert@diya-ua.com", "Expert"))
                Roles.AddUsersToRoles(new[] { "expert@diya-ua.com" }, new[] { "Expert" });
            if (!Roles.IsUserInRole("user@diya-ua.com", "User"))
                Roles.AddUsersToRoles(new[] { "user@diya-ua.com" }, new[] { "User" });
            if (!Roles.IsUserInRole("kohut.mykola@gmail.com", "Admin"))
                Roles.AddUsersToRoles(new[] { "kohut.mykola@gmail.com" }, new[] { "Admin", "Expert", "User" });
            if (!Roles.IsUserInRole("mrsmithjr@mail.ru", "Admin"))
                Roles.AddUsersToRoles(new[] { "mrsmithjr@mail.ru" }, new[] { "Admin", "Expert", "User" });

            CreateCategories(context);
            CreateIdeas(context);
            context.SaveChanges();
        }

        private void CreateCategories(UsersContext context)
        {
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Культура" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Соціальний" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Екологія" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Освіта" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Технології" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Підприємництво" });
            context.Categories.AddOrUpdate(x => x.Name, new Category { Name = "Інше" });
        }

        private void CreateIdeas(UsersContext context)
        {
            context.Ideas.Add(new Idea { UserId = 1, IdeaID = 1, Title = "Великий проект", CategoryId = 4, Description = "опис невеликий", Image = "/uploads/97a762ea-9156-4a2b-9b57-1141c7fc334c.gif" });
            context.Ideas.Add(new Idea { UserId = 1, IdeaID = 2, Title = "Великий проект 2", CategoryId = 1, Description = "опис невеликий2", Image = "/uploads/2a2081ca-d0c0-4961-94c9-1360b9a28875.jpg" });
        }
    }
}