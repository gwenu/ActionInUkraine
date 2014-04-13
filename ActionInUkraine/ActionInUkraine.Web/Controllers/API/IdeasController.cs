using ActionInUkraine.Entity;
using ActionInUkraine.Web.Implementations.Base;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Security;

namespace ActionInUkraine.Web.Controllers.API
{
    public class IdeasController : BaseApiController
    {
        public IdeasController()
            : base(null)
        {
        }

        // GET api/ideas
        public IEnumerable<Idea> Get()
        {
            var ideas = m_Repository.GetIdeas();
            return ideas;
        }

        // GET api/ideas/5
        public Idea Get(int id)
        {
            var idea = m_Repository.GetIdea(id);
            return idea;
        }

        // POST api/ideas
        public void Post([FromBody]Idea value)
        {
            try
            {
                value.Image = "/uploads/" + value.Image;
                value.UserId = (int)Membership.GetUser().ProviderUserKey;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} -  exception caught.", e);
            }

            m_Repository.AddIdea(value);
        }

        // PUT api/ideas/5
        public void Put(int id, [FromBody]Idea value)
        {
            m_Repository.UpdateIdea(id, value);
        }

        // DELETE api/ideas/5
        public void Delete(int id)
        {
            m_Repository.DeleteIdea(id);
        }
    }
}