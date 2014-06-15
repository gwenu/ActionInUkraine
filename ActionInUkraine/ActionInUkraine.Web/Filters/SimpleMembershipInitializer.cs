using ActionInUkraine.Entity;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ActionInUkraine.Web.Filters
{
    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            SqlConnection.ClearAllPools();
            Database.SetInitializer(new InitDB());
            var db = new UsersContext();
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
}