using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LOSA.BL;
using LOSA.Model;
using LOSA.DBL;

namespace LOSA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllFlights();
            System.Console.ReadLine();
        }

        static void GetAllFlights()

        {
            //Lazy loading
            //using (var context = new LOSAContext())
            //{
            //    var query = context.Flights
            //        .Include(f => f.Captain)
            //        .Include(f => f.Arrival)
            //        .Include(f => f.Departure)
            //        .Include(f => f.Plane);

            //    var query = context.Flights.ToList();
            //    PrintCurrentFlights(query);
            //}

            //Get airports
            using (var context = new LOSAContext())
            {
                var query =
                    from f in context.Flights
                    join a in context.Airports on
                        f.ArrivalAirportId equals a.AirportId
                    join d in context.Airports on
                        f.DepartureAirportId equals d.AirportId
                    select new { Arrival = a.Code, Departure = d.Code };
            }

            //Copy flights
            //var unit1 = new UnitOfWork();
            //using (unit1)
            //{
            //    var query1 = unit1.FlightsRepository.FindBy(null);
            //    foreach (var flight in query1)
            //    {
            //        if (flight.TakeOffTimeStamp != null)
            //        {
            //            flight.TakeOffTimeStamp = flight.TakeOffTimeStamp.Value.AddDays(7);
            //            unit1.FlightsRepository.Add(flight);
            //        }
            //    }
            //    unit1.Save();
            //}
            
            
        }

        static void PrintCurrentFlights(IEnumerable<Flight> flights)
        {
            System.Console.WriteLine("FlightID \tFlightObserver \tDeparture \tArriwal \tPlane");
            foreach (var flight in flights)
            {
                System.Console.WriteLine($"{flight.FlightId} \t{flight.Captain.FirstName} {flight.Captain.FirstName} \t{flight.Departure.Code} \t{flight.Arrival.Code} \t{flight.Plane.Code}");
            }
        }
    }
}
