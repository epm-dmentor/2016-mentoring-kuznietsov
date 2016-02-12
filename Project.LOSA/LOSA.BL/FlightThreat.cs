namespace LOSA.BL
{
    public class FlightThreat
    {
        public int Id { get; set; }
        public FlightObservation ParentObservation { get; set; }
        public string DetectedOnStage { get; set; }
        public ThreatType ThreatType { get; set; }
        public bool ThreatOutcome { get; set; }
    }
}
