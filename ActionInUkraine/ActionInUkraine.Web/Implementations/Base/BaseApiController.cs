using System.Web.Http;
using ActionInUkraine.Common;
using ActionInUkraine.Server.Fake;

namespace ActionInUkraine.Web.Implementations.Base
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IRepository m_Repository;

        protected BaseApiController(IRepository repository)
        {
            m_Repository = repository ?? new FakeRepository();
        }
    }
}