using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOSA.BL;

namespace LOSA.API.Controllers
{
    public class AirportController : ApiController
    {
        // GET: api/Airport
        public IHttpActionResult Get()
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.AirportsRepository.Get();
                return Ok(result.ToArray());

            }
        }

        // GET: api/Airport/5
        public IHttpActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var result = unit.FlightsRepository.Get(a => a.ArrivalAirportId == id).FirstOrDefault();
                if (result== null)
                    return NotFound();
                return
                    Ok(result);
            }
                
        }

        // POST: api/Airport
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Airport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Airport/5
        public void Delete(int id)
        {
        }
    }
}
