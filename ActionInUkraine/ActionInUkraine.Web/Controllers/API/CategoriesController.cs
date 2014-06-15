using ActionInUkraine.Web.Implementations.Base;
using System.Collections.Generic;
using System.Web.Http;

namespace ActionInUkraine.Web.Controllers.API
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController()
            : base(null)
        {
        }
        // GET api/categories
        public List<string> Get()
        {
            var categories = m_Repository.GetCategories();
            return categories;
        }

        // GET api/categories/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/categories
        public void Post([FromBody]string value)
        {
        }

        // PUT api/categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categories/5
        public void Delete(int id)
        {
        }
    }
}
