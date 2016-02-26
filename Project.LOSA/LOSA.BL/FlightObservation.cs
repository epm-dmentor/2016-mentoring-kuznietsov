using System.Collections.Generic;
using System.Linq;
using LOSA.Model.Entities;

namespace LOSA.Model
{
    public class FlightObservation
    {
        //Properties
        public int FlightObservationId { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Observer FlightObservingPerson { get; set; }
        public CrewMember TakeOffPilot { get; set; }
        public CrewMember LandingPilot { get; set; }
        public bool TakeoffDelay { get; set; }
        public bool CrewObserved { get; set; }
        public bool ThreatsObserved
        {
            get { return FlightThreats.Any(); }
        }

        public bool ErrorsObserved
        {
            get { return FlightErrors.Any(); }
        }

        public virtual List<FlightError> FlightErrors { get; set; }
        public virtual List<FlightThreat> FlightThreats { get; set; }
        
        //Constructor
        public FlightObservation(Flight observSubj, Observer observPerson)
        {
            Flight = observSubj;
            FlightObservingPerson = observPerson;
            FlightErrors = new List<FlightError>();
            FlightThreats = new List<FlightThreat>();
        }

        //Methods
    }
}
