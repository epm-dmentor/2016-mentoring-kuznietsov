using System.Collections.Generic;
using System.Linq;
using LOSA.BL.Entities;

namespace LOSA.BL
{
    public class FlightObservation
    {
        //Properties
        public int Id { get; set; }
        public Flight ObservedFlight { get; set; }
        public Observer FlightObservingPerson { get; set; }
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

        public List<FlightError> FlightErrors { get; set; }
        public List<FlightThreat> FlightThreats { get; set; }
        
        //Constructor
        public FlightObservation(Flight observSubj, Observer observPerson)
        {
            ObservedFlight = observSubj;
            FlightObservingPerson = observPerson;
            FlightErrors = new List<FlightError>();
            FlightThreats = new List<FlightThreat>();
        }

        //Methods
        public void AddError(FlightError typeOfError, FlightErrorOutcome outcome)
        {
            var error = new FlightError {ErrorType = typeOfError, ErrorOutcome = outcome, ParentObservation = this};
            FlightErrors.Add(error);
        }


        public void AddThreat(ThreatType typeOfThreat, bool outcome)
        {
            var threat = new FlightThreat {ThreatType = typeOfThreat, ThreatOutcome = outcome, ParentObservation = this};
            FlightThreats.Add(threat);
        }
    }
}
