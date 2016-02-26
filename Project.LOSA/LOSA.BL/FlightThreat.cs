using LOSA.Model.Entities;

namespace LOSA.Model
{
    public class FlightThreat
    {
        public int Id { get; set; }
        public int FlightObservationId { get; set; }
        public string DetectedOnStage { get; set; }
        public ThreatType ThreatType { get; set; }
        public bool ThreatOutcome { get; set; }
    }
}
