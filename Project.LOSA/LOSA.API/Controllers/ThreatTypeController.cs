using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class ThreatTypeController : ApiController
    {
        // GET: api/ThreatType
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ThreatTypesRepository.Get();
                return Ok(result.ToArray());
            }
        }

        // GET: api/ThreatType/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ThreatTypesRepository.Get(tt => tt.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/ThreatType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThreatType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ThreatType/5
        public void Delete(int id)
        {
        }
    }
}
