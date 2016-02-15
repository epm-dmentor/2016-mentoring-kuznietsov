using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOSA.BL.Entities
{
    public class FlightCrew
    {
        [Key]
        [Column(Order = 1)]
        public int FlightId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CrewMemberId { get; set; }
    }
}
