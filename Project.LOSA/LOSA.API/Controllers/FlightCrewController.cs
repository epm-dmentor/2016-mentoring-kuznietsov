using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.Model.Entities;

namespace LOSA.API.Controllers
{
    public class FlightCrewController : ApiController
    {
        // GET: api/FlightCrew
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightCrew/5
        public string Get(int id)
        {
            return "value";
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
