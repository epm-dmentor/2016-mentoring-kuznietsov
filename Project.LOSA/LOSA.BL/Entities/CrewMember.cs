using System;

namespace LOSA.BL.Entities
{
    public class CrewMember
    {
        public int CrewMemberId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public Position PositionId { get; set; }
        public bool InStaff { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalTime { get; set; }
    }
}
