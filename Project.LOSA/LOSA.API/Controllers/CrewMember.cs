using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;
using LOSA.Model.Entities;

namespace LOSA.API.Controllers
{
    public class CrewMemberController : ApiController
    {
        // GET: api/FlightCrew
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.CrewMembersRepository.Get();
                return Ok(result.ToArray());
            }
        }

        // GET: api/FlightCrew/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.CrewMembersRepository.Get(c => c.CrewMemberId == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/FlightCrew
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FlightCrew/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlightCrew/5
        public void Delete(int id)
        {
        }
    }
}
