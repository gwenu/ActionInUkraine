using System.Web.Mvc;
using ActionInUkraine.Common;
using ActionInUkraine.Server.Fake;

namespace ActionInUkraine.Web.Implementations.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly IRepository m_Repository;

        protected BaseController(IRepository repository)
        {
            m_Repository = repository ?? new FakeRepository();
        }
    }
}