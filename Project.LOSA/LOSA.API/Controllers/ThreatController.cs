using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class ThreatController : ApiController
    {
        // GET: api/Threat
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ThreatsRepository.Get()
                    .Include(t => t.ThreatType);
                return Ok(result.ToArray());
            }
        }

        // GET: api/Threat/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ThreatsRepository.Get(t => t.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/Threat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Threat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Threat/5
        public void Delete(int id)
        {
        }
    }
}
