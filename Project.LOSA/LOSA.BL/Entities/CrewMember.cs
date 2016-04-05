using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace LOSA.Model.Entities
{
    [DataContract]
    public class CrewMember
    {
        [DataMember]
        public int CrewMemberId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public bool InStaff { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalTime { get; set; }
        public virtual Position Position { get; set; }
        public int PositionId { get; set; }
        [XmlIgnore]
        public virtual ICollection<Flight> Flights { get; set; }

    }
}
