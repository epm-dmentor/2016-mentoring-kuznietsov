using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class EvaluationTakeoffController : ApiController
    {
        // GET: api/EvaluationTakeoff
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationTakeoffsRepository.Get();
                return Ok(result.ToArray());
            }
        }

        // GET: api/EvaluationTakeoff/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.EvaluationTakeoffsRepository.Get(el => el.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/EvaluationTakeoff
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EvaluationTakeoff/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EvaluationTakeoff/5
        public void Delete(int id)
        {
        }
    }
}
