using System.Web.Mvc;

namespace ActionInUkraine.Web.Controllers
{
    public class durandalController : Controller
    {
        public ActionResult shell()
        {
            return View();
        }
        public ActionResult home()
        {
            return View();
        }
        public ActionResult menu(string id)
        {
            return View(@"menu\" + id);
        }
        public ActionResult news(string id)
        {
            return View(@"news\" + id);
        }
        public ActionResult ideas(string id)
        {
            return View(@"ideas\" + id);
        }
        public ActionResult registration()
        {
            return View();
        }
        public ActionResult profile_registration()
        {
            return View();
        }
    }
}