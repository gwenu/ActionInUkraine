using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System.Linq;
using System.Web.Mvc;

namespace ActionInUkraine.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base(null)
        {
        }

        public ActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var db = new UsersContext();
                ViewBag.FirstName = db.UserProfiles.First(c => c.Email == User.Identity.Name).FirstName;
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}