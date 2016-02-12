namespace LOSA.DBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightErrors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DetectedOnStage = c.String(),
                        ErrorOutcome = c.Int(nullable: false),
                        ErrorType_Id = c.Int(),
                        ParentObservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightErrors", t => t.ErrorType_Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .Index(t => t.ErrorType_Id)
                .Index(t => t.ParentObservation_Id);
            
            CreateTable(
                "dbo.FlightObservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeOffPilot = c.Int(nullable: false),
                        LandingPilot = c.Int(nullable: false),
                        TakeoffDelay = c.Boolean(nullable: false),
                        CrewObserved = c.Boolean(nullable: false),
                        CurrentFlightObserver_Id = c.Int(),
                        FlightObservingPerson_Id = c.Int(),
                        ObservedFlight_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Observers", t => t.CurrentFlightObserver_Id)
                .ForeignKey("dbo.Observers", t => t.FlightObservingPerson_Id)
                .ForeignKey("dbo.Flights", t => t.ObservedFlight_Id)
                .Index(t => t.CurrentFlightObserver_Id)
                .Index(t => t.FlightObservingPerson_Id)
                .Index(t => t.ObservedFlight_Id);
            
            CreateTable(
                "dbo.Observers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightThreats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DetectedOnStage = c.String(),
                        ThreatOutcome = c.Boolean(nullable: false),
                        ParentObservation_Id = c.Int(),
                        ThreatType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .ForeignKey("dbo.ThreatTypes", t => t.ThreatType_Id)
                .Index(t => t.ParentObservation_Id)
                .Index(t => t.ThreatType_Id);
            
            CreateTable(
                "dbo.ThreatTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeOffTimeStamp = c.DateTime(nullable: false),
                        LandingTimeStamp = c.DateTime(nullable: false),
                        CurrentFlightStage = c.String(),
                        Arriwal_Id = c.Int(),
                        Departure_Id = c.Int(),
                        Plane_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.Arriwal_Id)
                .ForeignKey("dbo.Airports", t => t.Departure_Id)
                .ForeignKey("dbo.Planes", t => t.Plane_Id)
                .Index(t => t.Arriwal_Id)
                .Index(t => t.Departure_Id)
                .Index(t => t.Plane_Id);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvaluationLandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SOPBriefing = c.Int(nullable: false),
                        PlansStated = c.Int(nullable: false),
                        ContingencyManagement = c.Int(nullable: false),
                        MonitorCrosscheck = c.Int(nullable: false),
                        WorkloadManagement = c.Int(nullable: false),
                        Vigilance = c.Int(nullable: false),
                        AutomationManagement = c.Int(nullable: false),
                        TaxiwayRunwayManagement = c.Int(nullable: false),
                        PlansEvaluation = c.Int(nullable: false),
                        Inquiry = c.Int(nullable: false),
                        ParentObservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .Index(t => t.ParentObservation_Id);
            
            CreateTable(
                "dbo.EvaluationPredepartures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SOPBriefing = c.Int(nullable: false),
                        PlansStated = c.Int(nullable: false),
                        ContingencyManagement = c.Int(nullable: false),
                        MonitorCrosscheck = c.Int(nullable: false),
                        WorkloadManagement = c.Int(nullable: false),
                        Vigilance = c.Int(nullable: false),
                        AutomationManagement = c.Int(nullable: false),
                        TaxiwayRunwayManagement = c.Int(nullable: false),
                        PlansEvaluation = c.Int(nullable: false),
                        Inquiry = c.Int(nullable: false),
                        ParentObservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .Index(t => t.ParentObservation_Id);
            
            CreateTable(
                "dbo.EvaluationTakeOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonitorCrosscheck = c.Int(nullable: false),
                        WorkloadManagement = c.Int(nullable: false),
                        Vigilance = c.Int(nullable: false),
                        AutomationManagement = c.Int(nullable: false),
                        PlansEvaluation = c.Int(nullable: false),
                        Inquiry = c.Int(nullable: false),
                        ParentObservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .Index(t => t.ParentObservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvaluationTakeOffs", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.EvaluationPredepartures", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.EvaluationLandings", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightObservations", "ObservedFlight_Id", "dbo.Flights");
            DropForeignKey("dbo.Flights", "Plane_Id", "dbo.Planes");
            DropForeignKey("dbo.Flights", "Departure_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "Arriwal_Id", "dbo.Airports");
            DropForeignKey("dbo.FlightThreats", "ThreatType_Id", "dbo.ThreatTypes");
            DropForeignKey("dbo.FlightThreats", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightObservations", "FlightObservingPerson_Id", "dbo.Observers");
            DropForeignKey("dbo.FlightErrors", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightObservations", "CurrentFlightObserver_Id", "dbo.Observers");
            DropForeignKey("dbo.FlightErrors", "ErrorType_Id", "dbo.FlightErrors");
            DropIndex("dbo.EvaluationTakeOffs", new[] { "ParentObservation_Id" });
            DropIndex("dbo.EvaluationPredepartures", new[] { "ParentObservation_Id" });
            DropIndex("dbo.EvaluationLandings", new[] { "ParentObservation_Id" });
            DropIndex("dbo.Flights", new[] { "Plane_Id" });
            DropIndex("dbo.Flights", new[] { "Departure_Id" });
            DropIndex("dbo.Flights", new[] { "Arriwal_Id" });
            DropIndex("dbo.FlightThreats", new[] { "ThreatType_Id" });
            DropIndex("dbo.FlightThreats", new[] { "ParentObservation_Id" });
            DropIndex("dbo.FlightObservations", new[] { "ObservedFlight_Id" });
            DropIndex("dbo.FlightObservations", new[] { "FlightObservingPerson_Id" });
            DropIndex("dbo.FlightObservations", new[] { "CurrentFlightObserver_Id" });
            DropIndex("dbo.FlightErrors", new[] { "ParentObservation_Id" });
            DropIndex("dbo.FlightErrors", new[] { "ErrorType_Id" });
            DropTable("dbo.EvaluationTakeOffs");
            DropTable("dbo.EvaluationPredepartures");
            DropTable("dbo.EvaluationLandings");
            DropTable("dbo.ErrorTypes");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
            DropTable("dbo.ThreatTypes");
            DropTable("dbo.FlightThreats");
            DropTable("dbo.Observers");
            DropTable("dbo.FlightObservations");
            DropTable("dbo.FlightErrors");
            DropTable("dbo.Airports");
        }
    }
}
