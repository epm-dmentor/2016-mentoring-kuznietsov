﻿using LOSA.BL.Enums;

namespace LOSA.BL
{
    public class EvaluationPredeparture
    {
        public int Id { get; set; } 
        public FlightObservation ParentObservation { get; set; }
        public EvaluationScale SOPBriefing { get; set; }
        public EvaluationScale PlansStated { get; set; }
        public EvaluationScale ContingencyManagement { get; set; }
        public EvaluationScale MonitorCrosscheck { get; set; }
        public EvaluationScale WorkloadManagement { get; set; }
        public EvaluationScale Vigilance { get; set; }
        public EvaluationScale AutomationManagement { get; set; }
        public EvaluationScale TaxiwayRunwayManagement { get; set; }
        public EvaluationScale PlansEvaluation { get; set; }
        public EvaluationScale Inquiry { get; set; }
    }
}
