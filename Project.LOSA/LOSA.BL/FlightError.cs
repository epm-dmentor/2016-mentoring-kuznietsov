namespace LOSA.BL
{
    class FlightError
    {
        public int Id { get; set; }
        public FlightObservation FlightObservation { get; set; }    
        public FlightErrors ErrorType { get; set; }
        public FlightErrorOutcome ErrorOutcome { get; set; }
    }
}
