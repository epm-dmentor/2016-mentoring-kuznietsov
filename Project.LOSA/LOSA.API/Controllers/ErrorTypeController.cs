using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class ErrorTypeController : ApiController
    {
        // GET: api/ErrorType
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ErrorTypesRepository.Get();
                return Ok(result.ToArray();
            }
        }

        // GET: api/ErrorType/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ErrorTypesRepository.Get(e => e.Id == id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
        }

        // POST: api/ErrorType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ErrorType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ErrorType/5
        public void Delete(int id)
        {
        }
    }
}
