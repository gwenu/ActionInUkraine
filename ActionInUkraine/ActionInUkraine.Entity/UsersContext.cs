using System.Data.Entity;

namespace ActionInUkraine.Entity
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Article> Articles { get; set; }
        //public DbSet<Event> Events { get; set; }
        //public DbSet<Expense> Expenses { get; set; }
        //public DbSet<ExternalUserInformation> ExternalUsers { get; set; }
    }
}
