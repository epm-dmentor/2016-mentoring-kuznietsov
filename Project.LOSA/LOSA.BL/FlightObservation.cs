using System.Collections.Generic;

namespace LOSA.BL
{
    class FlightObservation
    {
        //Properties
        public int Id { get; set; }
        public Flight ObservedFlight { get; set; }
        public PilotType TakeOffPilot { get; set; }
        public PilotType LandingPilot { get; set; }
        public Observers CurrentFlightObserver { get; set; }
        public bool TakeoffDelay { get; set; }
        public bool CrewObserved { get; set; }
        public bool ThreatsObserved { get; set; }
        public bool ErrorsObserved { get; set; }
        private List<FlightError> FlightErrors { get; set; }
        private List<FlightThreat> FlightThreats { get; set; }
        
        //Constructor
        public FlightObservation()
        {
            FlightErrors = new List<FlightError>();
            FlightThreats = new List<FlightThreat>();
        }

        //Methods
        public void NewError(FlightErrors typeOfError, FlightErrorOutcome outcome)
        {
            var error = new FlightError {ErrorType = typeOfError, ErrorOutcome = outcome, FlightObservation = this};
            FlightErrors.Add(error);
        }


        public void NewThreat(FlightThreats typeOfThreat, bool outcome)
        {
            var threat = new FlightThreat {ThreatType = typeOfThreat, ThreatOutcome = outcome, FlightObservation = this};
            FlightThreats.Add(threat);
        }
    }
}
