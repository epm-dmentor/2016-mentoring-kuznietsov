using LOSA.BL;
using LOSA.BL.Entities;

namespace LOSA.DBL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LOSAContext : DbContext
    {
        // Your context has been configured to use a 'LOSACOntext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LOSA.DBL.LOSACOntext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LOSACOntext' 
        // connection string in the application configuration file.
        public LOSAContext()
            : base("name=LOSAContext")
        {
        }

        public DbSet<FlightObservation> Observations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightError> Errors { get; set; }
        public DbSet<FlightThreat> Threats { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<ErrorType> ErrorTypes { get; set; }
        public DbSet<Observer> Observers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<ThreatType> ThreatTypes { get; set; }
        public DbSet<EvaluationLanding> LandingEvaluations { get; set; }
        public DbSet<EvaluationPredeparture> PredepartureEvaluations { get; set; }
        public DbSet<EvaluationTakeOff> TakeOffEvaluations { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<Position> CrewPositions { get; set; }
        public DbSet<FlightCrew> FlightCrews { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}