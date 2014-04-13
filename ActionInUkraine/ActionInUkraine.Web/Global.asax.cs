using ActionInUkraine.Entity;
using ActionInUkraine.Web.App_Start;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ActionInUkraine.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref m_initializer, ref m_isInitialized, ref m_initializerLock);
        }

        private static SimpleMembershipInitializer m_initializer;
        private static object m_initializerLock = new object();
        private static bool m_isInitialized;

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                SqlConnection.ClearAllPools();
                Database.SetInitializer(new InitDB());
                UsersContext db = new UsersContext();
                db.Database.Initialize(true);
                //try
                //{
                //    using (var context = new UsersContext())
                //    {
                //        if (!context.Database.Exists())
                //        {
                //            // Create the SimpleMembership database without Entity Framework migration schema
                //            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                //        }
                //    }
                //    WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
                //    if (!WebMatrix.WebData.WebSecurity.UserExists("kohut.mykola@gmail.com"))
                //        ActionInUkraine.Web.Implementations.Authentication.WebSecurity.CreateUserAndAccount("kohut.mykola@gmail.com", "111111", "Mykola", "Kohut", "male", DateTime.Now, false);
                //}
                //catch (Exception ex)
                //{
                //    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                //}
            }
        }
        public class InitDB : DropCreateDatabaseAlways<UsersContext>
        {
            protected override void Seed(UsersContext context)
            {
                WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
                // if (!WebMatrix.WebData.WebSecurity.UserExists("kohut.mykola@gmail.com"))
                ActionInUkraine.Web.Implementations.Authentication.WebSecurity.CreateUserAndAccount("kohut.mykola@gmail.com", "111111", "Mykola", "Kohut", "male", DateTime.Now, false);
                ActionInUkraine.Web.Implementations.Authentication.WebSecurity.CreateUserAndAccount("mrsmithjr@mail.ru", "222222", "Тарас", "Романик", "male", DateTime.Now, false);

                CreateIdeas(context);
                context.SaveChanges();
            }

            private void CreateIdeas(UsersContext context)
            {
                context.Ideas.Add(new Idea { UserId = 1, IdeaID = 1, Title = "Великий проект", Category = "освіта", Description = "опис невеликий", Image = "/uploads/97a762ea-9156-4a2b-9b57-1141c7fc334c.gif" });
                context.Ideas.Add(new Idea { UserId = 1, IdeaID = 2, Title = "Великий проект 2", Category = "культура", Description = "опис невеликий2", Image = "/uploads/2a2081ca-d0c0-4961-94c9-1360b9a28875.jpg" });
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
        }
    }
}