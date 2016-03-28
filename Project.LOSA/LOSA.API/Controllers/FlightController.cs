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
    //[Authorize]
    public class FlightController : ApiController
    {
        // GET api/values
        //Is this the proper way to return result with IhhtpActionResult?
        public IEnumerable<IHttpActionResult> Get()
        {
            var unit = new UnitOfWork();
            using (unit)
            {
                IEnumerable<Flight> result =
                    unit.FlightsRepository.Get()
                        .Include(f => f.Arrival)
                        .Include(f => f.Plane)
                        .Include(f => f.Departure);
                        //(f => f.CrewMembers.Where(c => c.Flights.Contains(f)));
                foreach (var flight in result)
                {
                    yield return Ok(flight);
                }
            }
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            //Which of the implementations below is better?

            var unit = new UnitOfWork();
            using (unit)
            {
                var flight = unit.FlightsRepository.Get().FirstOrDefault(f => f.FlightId == id);
                if (flight == null)
                {
                    return NotFound();
                }
                return
                    Ok(flight);

                //if (unit.FlightsRepository.Get(f => f.FlightId == id) != null)
                //{
                //    return Ok(unit.FlightsRepository.Get(f => f.FlightId == id));
                //}
                //return NotFound();
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
