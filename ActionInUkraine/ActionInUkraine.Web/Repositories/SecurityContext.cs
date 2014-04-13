using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionInUkraine.Entity;
using ActionInUkraine.Web.Repositories.ModelConfiguration;

namespace ActionInUkraine.Web.Repositories
{
    public class SecurityContext : DbContext
    {
        public SecurityContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<OperationsToRoles> OperationsToRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ResourceConfiguration());
            modelBuilder.Configurations.Add(new OperationsToRolesConfiguration());
        }
    }

}
