﻿namespace LOSA.Model.Entities
{
    public class ThreatType
    {
        public int Id { get; set; }
        public int FlightObservationId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
