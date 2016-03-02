using System.Collections.Generic;
using System.Linq;
using LOSA.BL;
using LOSA.Model.Entities;

namespace LOSA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeAChoice();
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

            ////Get airports

            //Copy flights
            //var unit1 = new UnitOfWork();
            //using (unit1)
            //{
            //    var query1 = unit1.FlightsRepository.Get(null);
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


        public static IEnumerable<Airport> GetUsedAirports()
        {
            var unit = new UnitOfWork();
            using (unit)
            {
                var queryA =
                    from f in unit.FlightsRepository.Get()   //Add empty override
                    join a in unit.AirportsRepository.Get() on
                        f.ArrivalAirportId equals a.AirportId
                    select a;              
                
                var queryD = 
                    from f in unit.FlightsRepository.Get()
                    join d in unit.AirportsRepository.Get() on
                        f.DepartureAirportId equals d.AirportId
                    select d;

                return queryA.Distinct().Union(queryD.Distinct()).ToArray();
            }
        }

        public static IEnumerable<Airport> GetUnusedAirports()
        {
            var used = GetUsedAirports();
            var unit = new UnitOfWork();
            using (unit)
            {
                return unit.AirportsRepository.Get().ToArray().Except(used); //TO CHECK
            }
        }

        public static void PrintOut(IEnumerable<Airport> airports)
        {
            foreach (var airport in airports)
            {
                System.Console.WriteLine($"{airport.Code} \t {airport.Description}");
            }
        }

        public static void MakeAChoice()
        {
            System.Console.WriteLine("Print 1 to show all used and unused airports or any other key to exit");
            var key = System.Console.ReadLine();
            if (key == null || !key.Equals("1")) return;
            PrintOut(GetUsedAirports());
            System.Console.ReadLine();
            PrintOut(GetUnusedAirports());
            System.Console.ReadLine();
        }
    }
}

