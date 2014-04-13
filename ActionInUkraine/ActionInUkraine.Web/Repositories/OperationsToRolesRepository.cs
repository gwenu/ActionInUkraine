using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionInUkraine.Entity;

namespace ActionInUkraine.Web.Repositories
{
    public class OperationsToRolesRepository: GenericRepository<OperationsToRoles>
    {
        public OperationsToRolesRepository(SecurityContext context) : base(context) { }
    }
}
