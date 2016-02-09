namespace LOSA.BL
{
    class FlightThreat
    {
        public int Id { get; set; }
        public FlightObservation FlightObservation { get; set; }    
        public FlightThreats ThreatType { get; set; }
        public bool ThreatOutcome { get; set; }
    }
}
