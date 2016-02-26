using System;
using System.Collections.Generic;

namespace LOSA.Model.Entities
{
    public class CrewMember
    {
        public int CrewMemberId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public bool InStaff { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalTime { get; set; }
        public virtual Position Position { get; set; }
        public int PositionId { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

    }
}
