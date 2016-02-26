using LOSA.Model.Enums;
using LOSA.Model.Entities;

namespace LOSA.Model
{
    public class FlightError
    {
        public int Id { get; set; }
        public int FlightObservationId { get; set; }   
        public string ErrorDescription { get; set; }
        public string ErrorConsequencesDetails { get; set; }
        public FlightStage DetectedOnStage { get; set; }
        public int ErrorAttitude { get; set; }
        public bool ProfficiencyIssue { get; set; }
        //Bool with conditioned workflow????                            //????????

        public FlightError ErrorType { get; set; }
        public CrewMember CommitedBy { get; set; }
        public bool ErrorResponse { get; set; }    
        public FlightErrorOutcome ErrorOutcome { get; set; }
        public CrewMember DetectedBy { get; set; }                      //???????? what should be in a drop down?

    }
}
