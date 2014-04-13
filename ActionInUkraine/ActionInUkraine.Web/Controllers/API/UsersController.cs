using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ActionInUkraine.Web.Controllers.API
{
    public class UsersController : BaseApiController
    {
        public UsersController()
            : base(null)
        {
        }

        [HttpGet]
        public IEnumerable<dynamic> GetUsers(string query)
        {
            var _db = new UsersContext();
            var user = _db.UserProfiles.Where(c => c.UserId == 1).FirstOrDefault();
            var users2 = _db.UserProfiles.Select(c => c.FirstName);
            var result2 = (from s in _db.UserProfiles
                           where s.FirstName.Contains(query)
                           select s).Take(10);

            var names = query.Split(' ');
            IEnumerable<dynamic> result;

            if (2 == names.Length)
            {
                var firstName = names[0];
                var secondName = names[1];
                result = _db.UserProfiles
                    .Where(x => (x.FirstName.Contains(firstName) && x.SecondName.Contains(secondName))
                             || (x.FirstName.Contains(secondName) && x.SecondName.Contains(firstName)))
                    .Take(10);
            }
            else
                result = _db.UserProfiles
                    .Where(x => (x.FirstName.Contains(query) || x.SecondName.Contains(query)))
                    .Take(10);
            return result;
           
        }
    }
}