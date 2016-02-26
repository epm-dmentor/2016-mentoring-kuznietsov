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
                        AirportId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AirportId);
            
            CreateTable(
                "dbo.CrewMembers",
                c => new
                    {
                        CrewMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        FamilyName = c.String(),
                        InStaff = c.Boolean(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        DismissalTime = c.DateTime(),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewMemberId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        PlaneId = c.Int(nullable: false),
                        DepartureAirportId = c.Int(nullable: false),
                        ArrivalAirportId = c.Int(nullable: false),
                        TakeOffTimeStamp = c.DateTime(),
                        LandingTimeStamp = c.DateTime(),
                        CurrentFlightAttitude = c.Int(),
                        CurrentFlightStage = c.Int(nullable: false),
                        Captain_CrewMemberId = c.Int(),
                        FirstOfficer_CrewMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.Airports", t => t.ArrivalAirportId)
                .ForeignKey("dbo.CrewMembers", t => t.Captain_CrewMemberId)
                .ForeignKey("dbo.Airports", t => t.DepartureAirportId)
                .ForeignKey("dbo.CrewMembers", t => t.FirstOfficer_CrewMemberId)
                .ForeignKey("dbo.Planes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PlaneId)
                .Index(t => t.DepartureAirportId)
                .Index(t => t.ArrivalAirportId)
                .Index(t => t.Captain_CrewMemberId)
                .Index(t => t.FirstOfficer_CrewMemberId);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(),
                        PositionDescription = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.FlightErrors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
                        ErrorDescription = c.String(),
                        ErrorConsequencesDetails = c.String(),
                        DetectedOnStage = c.Int(nullable: false),
                        ErrorAttitude = c.Int(nullable: false),
                        ProfficiencyIssue = c.Boolean(nullable: false),
                        ErrorResponse = c.Boolean(nullable: false),
                        ErrorOutcome = c.Int(nullable: false),
                        CommitedBy_CrewMemberId = c.Int(),
                        DetectedBy_CrewMemberId = c.Int(),
                        ErrorType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrewMembers", t => t.CommitedBy_CrewMemberId)
                .ForeignKey("dbo.CrewMembers", t => t.DetectedBy_CrewMemberId)
                .ForeignKey("dbo.FlightErrors", t => t.ErrorType_Id)
                .ForeignKey("dbo.FlightObservations", t => t.FlightObservationId, cascadeDelete: true)
                .Index(t => t.FlightObservationId)
                .Index(t => t.CommitedBy_CrewMemberId)
                .Index(t => t.DetectedBy_CrewMemberId)
                .Index(t => t.ErrorType_Id);
            
            CreateTable(
                "dbo.ErrorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvaluationLandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightObservations",
                c => new
                    {
                        FlightObservationId = c.Int(nullable: false, identity: true),
                        TakeoffDelay = c.Boolean(nullable: false),
                        CrewObserved = c.Boolean(nullable: false),
                        Flight_FlightId = c.Int(),
                        FlightObservingPerson_Id = c.Int(),
                        LandingPilot_CrewMemberId = c.Int(),
                        TakeOffPilot_CrewMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightObservationId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .ForeignKey("dbo.Observers", t => t.FlightObservingPerson_Id)
                .ForeignKey("dbo.CrewMembers", t => t.LandingPilot_CrewMemberId)
                .ForeignKey("dbo.CrewMembers", t => t.TakeOffPilot_CrewMemberId)
                .Index(t => t.Flight_FlightId)
                .Index(t => t.FlightObservingPerson_Id)
                .Index(t => t.LandingPilot_CrewMemberId)
                .Index(t => t.TakeOffPilot_CrewMemberId);
            
            CreateTable(
                "dbo.Observers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightThreats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
                        DetectedOnStage = c.String(),
                        ThreatOutcome = c.Boolean(nullable: false),
                        ThreatType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThreatTypes", t => t.ThreatType_Id)
                .ForeignKey("dbo.FlightObservations", t => t.FlightObservationId, cascadeDelete: true)
                .Index(t => t.FlightObservationId)
                .Index(t => t.ThreatType_Id);
            
            CreateTable(
                "dbo.ThreatTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvaluationPredepartures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvaluationTakeOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightObservationId = c.Int(nullable: false),
                        MonitorCrosscheck = c.Int(nullable: false),
                        WorkloadManagement = c.Int(nullable: false),
                        Vigilance = c.Int(nullable: false),
                        AutomationManagement = c.Int(nullable: false),
                        PlansEvaluation = c.Int(nullable: false),
                        Inquiry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightCrews",
                c => new
                    {
                        FlightId = c.Int(nullable: false),
                        CrewMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlightId, t.CrewMemberId })
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.CrewMembers", t => t.CrewMemberId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.CrewMemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightObservations", "TakeOffPilot_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightObservations", "LandingPilot_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightThreats", "FlightObservationId", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightThreats", "ThreatType_Id", "dbo.ThreatTypes");
            DropForeignKey("dbo.FlightObservations", "FlightObservingPerson_Id", "dbo.Observers");
            DropForeignKey("dbo.FlightErrors", "FlightObservationId", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightObservations", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.FlightErrors", "ErrorType_Id", "dbo.FlightErrors");
            DropForeignKey("dbo.FlightErrors", "DetectedBy_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightErrors", "CommitedBy_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.CrewMembers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Flights", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Flights", "FirstOfficer_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.Flights", "DepartureAirportId", "dbo.Airports");
            DropForeignKey("dbo.FlightCrews", "CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightCrews", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "Captain_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.Flights", "ArrivalAirportId", "dbo.Airports");
            DropIndex("dbo.FlightCrews", new[] { "CrewMemberId" });
            DropIndex("dbo.FlightCrews", new[] { "FlightId" });
            DropIndex("dbo.FlightThreats", new[] { "ThreatType_Id" });
            DropIndex("dbo.FlightThreats", new[] { "FlightObservationId" });
            DropIndex("dbo.FlightObservations", new[] { "TakeOffPilot_CrewMemberId" });
            DropIndex("dbo.FlightObservations", new[] { "LandingPilot_CrewMemberId" });
            DropIndex("dbo.FlightObservations", new[] { "FlightObservingPerson_Id" });
            DropIndex("dbo.FlightObservations", new[] { "Flight_FlightId" });
            DropIndex("dbo.FlightErrors", new[] { "ErrorType_Id" });
            DropIndex("dbo.FlightErrors", new[] { "DetectedBy_CrewMemberId" });
            DropIndex("dbo.FlightErrors", new[] { "CommitedBy_CrewMemberId" });
            DropIndex("dbo.FlightErrors", new[] { "FlightObservationId" });
            DropIndex("dbo.Flights", new[] { "FirstOfficer_CrewMemberId" });
            DropIndex("dbo.Flights", new[] { "Captain_CrewMemberId" });
            DropIndex("dbo.Flights", new[] { "ArrivalAirportId" });
            DropIndex("dbo.Flights", new[] { "DepartureAirportId" });
            DropIndex("dbo.Flights", new[] { "PlaneId" });
            DropIndex("dbo.CrewMembers", new[] { "PositionId" });
            DropTable("dbo.FlightCrews");
            DropTable("dbo.EvaluationTakeOffs");
            DropTable("dbo.EvaluationPredepartures");
            DropTable("dbo.ThreatTypes");
            DropTable("dbo.FlightThreats");
            DropTable("dbo.Observers");
            DropTable("dbo.FlightObservations");
            DropTable("dbo.EvaluationLandings");
            DropTable("dbo.ErrorTypes");
            DropTable("dbo.FlightErrors");
            DropTable("dbo.Positions");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
            DropTable("dbo.CrewMembers");
            DropTable("dbo.Airports");
        }
    }
}
