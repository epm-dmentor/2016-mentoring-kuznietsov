using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;
using LOSA.Model;

namespace LOSA.API.Controllers
{
    public class ObservationController : ApiController
    {
        // GET: api/Observation
        public IEnumerable<IHttpActionResult> Get()
        {
            var unit = new UnitOfWork();
            using (unit)
            {
                IEnumerable<FlightObservation> result =
                    unit.ObservationsRepository.Get()
                        .Include(o => o.Flight)
                        .Include(o => o.FlightObservingPerson)
                        .Include(o => o.FlightErrors)
                        .Include(o => o.FlightThreats);
                foreach (var flightObservation in result)
                {
                    yield return Ok(flightObservation);
                }
            }
        }

        // GET: api/Observation/5
        public IHttpActionResult Get(int id)
        {
            var unit = new UnitOfWork();
            var result = unit.ObservationsRepository.Get().FirstOrDefault(o => o.FlightObservationId == id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/Observation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Observation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Observation/5
        public void Delete(int id)
        {
        }
    }
}
