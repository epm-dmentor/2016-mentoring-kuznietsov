using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LOSA.Model.Entities;

namespace LOSA.Model
{
    public class Flight
    {
        //Properties
        public int FlightId { get; set; }
        public virtual Plane Plane { get; set; }
        public int PlaneId { get; set; }
        public virtual Airport Departure { get; set; }
        public int DepartureAirportId { get; set; }
        public virtual Airport Arrival { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime? TakeOffTimeStamp { get; set; }
        public DateTime? LandingTimeStamp { get; set; }
        public int? CurrentFlightAttitude { get; set; }
        public FlightStage CurrentFlightStage { get; set; }
        public virtual ICollection<CrewMember> CrewMembers { get; set; }

        //Constructor


        //Methods
    }
}
