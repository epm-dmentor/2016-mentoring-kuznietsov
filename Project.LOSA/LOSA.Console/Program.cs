using System.Collections.Generic;
using System.Data.Entity;
using LOSA.BL;
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
            using (var context = new LOSAContext())
            {
                var query = context.Flights
                    .Include(f => f.Captain)
                    .Include(f => f.Arriwal)
                    .Include(f => f.Departure)
                    .Include(f => f.Plane);
                PrintCurrentFlights(query);
            }
        }

        static void PrintCurrentFlights(IEnumerable<Flight> flights)
        {
            System.Console.WriteLine("FlightID \tFlightObserver \tDeparture \tArriwal \tPlane");
            foreach (var flight in flights)
            {
                System.Console.WriteLine($"{flight.FlightId} \t{flight.Captain.FirstName} {flight.Captain.FirstName} \t{flight.Departure.Code} \t{flight.Arriwal.Code} \t{flight.Plane.Code}");
            }
        }
    }
}
