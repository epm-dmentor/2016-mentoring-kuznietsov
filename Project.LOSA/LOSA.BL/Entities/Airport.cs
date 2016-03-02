using System;

namespace LOSA.Model.Entities
{
    public class Airport : IEquatable<Airport>
    {
        public int AirportId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool Equals(Airport other)
        {
            return other.AirportId == AirportId;
        }

        public override int GetHashCode()
        {
            return AirportId.GetHashCode();
        }
    }
}
