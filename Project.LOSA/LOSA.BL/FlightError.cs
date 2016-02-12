namespace LOSA.BL
{
    public class FlightError
    {
        public int Id { get; set; }
        public FlightObservation ParentObservation { get; set; }   
        public string DetectedOnStage { get; set; } 
        public FlightError ErrorType { get; set; }
        public FlightErrorOutcome ErrorOutcome { get; set; }
    }
}
