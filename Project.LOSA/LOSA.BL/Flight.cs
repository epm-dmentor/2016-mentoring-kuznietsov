using System;
using LOSA.BL.Entities;

namespace LOSA.BL
{
    public class Flight
    {
        //Properties
        public int FlightId { get; set; }
        public Plane Plane { get; set; }
        public CrewMember Captain { get; set; }
        public CrewMember FirstOfficer { get; set; }
        public Airport Departure { get; set; }
        public Airport Arriwal { get; set; }
        public DateTime? TakeOffTimeStamp { get; set; }
        public DateTime? LandingTimeStamp { get; set; }
        public int? CurrentFlightAttitude { get; set; }
        public FlightStage CurrentFlightStage { get; set; }

        //Constructor
        public Flight() {}

        //Methods
    }
}
