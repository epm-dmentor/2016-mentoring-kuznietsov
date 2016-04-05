using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class EvaluationLandingController : ApiController
    {
        // GET: api/EvaluationLanding
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationLandingsRepository.Get();
                return Ok(result.ToArray());
            }
        }

        // GET: api/EvaluationLanding/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationLandingsRepository.Get(el => el.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/EvaluationLanding
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EvaluationLanding/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EvaluationLanding/5
        public void Delete(int id)
        {
        }
    }
}
