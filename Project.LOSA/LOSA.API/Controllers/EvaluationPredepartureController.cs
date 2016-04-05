using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class EvaluationPredepartureController : ApiController
    {
        // GET: api/EvaluationPredeparture
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationPredeparturesRepository.Get();
                return Ok(result.ToArray());
            }
        }

        // GET: api/EvaluationPredeparture/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationPredeparturesRepository.Get(el => el.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/EvaluationPredeparture
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EvaluationPredeparture/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EvaluationPredeparture/5
        public void Delete(int id)
        {
        }
    }
}
