using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;
using LOSA.Model.Entities;

namespace LOSA.API.Controllers
{
    public class ErrorController : ApiController
    {
        // GET: api/Error
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ErrorsRepository.Get()
                    .Include(e => e.ErrorType)
                    .Include(e => e.CommitedBy)
                    .Include(e => e.DetectedBy);

                return Ok(result.ToArray());
            }
        }

        // GET: api/Error/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.ErrorsRepository.Get(e => e.Id == id).FirstOrDefault();
                if (result == null)
                    return NotFound();
                return
                    Ok(result);
            }
        }

        // POST: api/Error
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Error/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Error/5
        public void Delete(int id)
        {
        }
    }
}
