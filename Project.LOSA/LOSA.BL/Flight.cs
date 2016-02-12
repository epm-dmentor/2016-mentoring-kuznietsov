using System;
using System.Collections.Generic;
using System.Linq;

namespace LOSA.BL
{
    public class Flight
    {
        //Properties
        public int Id { get; set; }
        public Plane Plane { get; set; }
        public Airport Departure { get; set; }
        public Airport Arriwal { get; set; }
        public DateTime TakeOffTimeStamp { get; set; }
        public DateTime LandingTimeStamp { get; set; } 
        public string CurrentFlightStage { get; set; }

        //Constructor
        public Flight() {}

        //Methods
    }
}
