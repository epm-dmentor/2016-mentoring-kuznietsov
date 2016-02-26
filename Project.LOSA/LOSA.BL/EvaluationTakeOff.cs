using LOSA.Model.Enums;

namespace LOSA.Model
{
    public class EvaluationTakeOff
    {
        public int Id { get; set; }
        public int FlightObservationId { get; set; }
        public EvaluationScale MonitorCrosscheck { get; set; }
        public EvaluationScale WorkloadManagement { get; set; }
        public EvaluationScale Vigilance { get; set; }
        public EvaluationScale AutomationManagement { get; set; }
        public EvaluationScale PlansEvaluation { get; set; }
        public EvaluationScale Inquiry { get; set; }
    }
}
