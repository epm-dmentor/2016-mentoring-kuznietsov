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
                "dbo.CrewMembers",
                c => new
                    {
                        CrewMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        FamilyName = c.String(),
                        InStaff = c.Boolean(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        DismissalTime = c.DateTime(nullable: false),
                        PositionId_PositionId = c.Int(),
                    })
                .PrimaryKey(t => t.CrewMemberId)
                .ForeignKey("dbo.Positions", t => t.PositionId_PositionId)
                .Index(t => t.PositionId_PositionId);
            
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
                        ParentObservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrewMembers", t => t.CommitedBy_CrewMemberId)
                .ForeignKey("dbo.CrewMembers", t => t.DetectedBy_CrewMemberId)
                .ForeignKey("dbo.FlightErrors", t => t.ErrorType_Id)
                .ForeignKey("dbo.FlightObservations", t => t.ParentObservation_Id)
                .Index(t => t.CommitedBy_CrewMemberId)
                .Index(t => t.DetectedBy_CrewMemberId)
                .Index(t => t.ErrorType_Id)
                .Index(t => t.ParentObservation_Id);
            
            CreateTable(
                "dbo.FlightObservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeoffDelay = c.Boolean(nullable: false),
                        CrewObserved = c.Boolean(nullable: false),
                        FlightObservingPerson_Id = c.Int(),
                        LandingPilot_CrewMemberId = c.Int(),
                        ObservedFlight_FlightId = c.Int(),
                        TakeOffPilot_CrewMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Observers", t => t.FlightObservingPerson_Id)
                .ForeignKey("dbo.CrewMembers", t => t.LandingPilot_CrewMemberId)
                .ForeignKey("dbo.Flights", t => t.ObservedFlight_FlightId)
                .ForeignKey("dbo.CrewMembers", t => t.TakeOffPilot_CrewMemberId)
                .Index(t => t.FlightObservingPerson_Id)
                .Index(t => t.LandingPilot_CrewMemberId)
                .Index(t => t.ObservedFlight_FlightId)
                .Index(t => t.TakeOffPilot_CrewMemberId);
            
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
                        FlightId = c.Int(nullable: false, identity: true),
                        TakeOffTimeStamp = c.DateTime(nullable: false),
                        LandingTimeStamp = c.DateTime(nullable: false),
                        CurrentFlightAttitude = c.Int(nullable: false),
                        CurrentFlightStage = c.Int(nullable: false),
                        Arriwal_Id = c.Int(),
                        Captain_CrewMemberId = c.Int(),
                        Departure_Id = c.Int(),
                        FirstOfficer_CrewMemberId = c.Int(),
                        Plane_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.Airports", t => t.Arriwal_Id)
                .ForeignKey("dbo.CrewMembers", t => t.Captain_CrewMemberId)
                .ForeignKey("dbo.Airports", t => t.Departure_Id)
                .ForeignKey("dbo.CrewMembers", t => t.FirstOfficer_CrewMemberId)
                .ForeignKey("dbo.Planes", t => t.Plane_Id)
                .Index(t => t.Arriwal_Id)
                .Index(t => t.Captain_CrewMemberId)
                .Index(t => t.Departure_Id)
                .Index(t => t.FirstOfficer_CrewMemberId)
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
                "dbo.FlightCrews",
                c => new
                    {
                        FlightId = c.Int(nullable: false),
                        CrewMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlightId, t.CrewMemberId });
            
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
            DropForeignKey("dbo.FlightObservations", "TakeOffPilot_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightObservations", "ObservedFlight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "Plane_Id", "dbo.Planes");
            DropForeignKey("dbo.Flights", "FirstOfficer_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.Flights", "Departure_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "Captain_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.Flights", "Arriwal_Id", "dbo.Airports");
            DropForeignKey("dbo.FlightObservations", "LandingPilot_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightThreats", "ThreatType_Id", "dbo.ThreatTypes");
            DropForeignKey("dbo.FlightThreats", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightObservations", "FlightObservingPerson_Id", "dbo.Observers");
            DropForeignKey("dbo.FlightErrors", "ParentObservation_Id", "dbo.FlightObservations");
            DropForeignKey("dbo.FlightErrors", "ErrorType_Id", "dbo.FlightErrors");
            DropForeignKey("dbo.FlightErrors", "DetectedBy_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.FlightErrors", "CommitedBy_CrewMemberId", "dbo.CrewMembers");
            DropForeignKey("dbo.CrewMembers", "PositionId_PositionId", "dbo.Positions");
            DropIndex("dbo.EvaluationTakeOffs", new[] { "ParentObservation_Id" });
            DropIndex("dbo.EvaluationPredepartures", new[] { "ParentObservation_Id" });
            DropIndex("dbo.EvaluationLandings", new[] { "ParentObservation_Id" });
            DropIndex("dbo.Flights", new[] { "Plane_Id" });
            DropIndex("dbo.Flights", new[] { "FirstOfficer_CrewMemberId" });
            DropIndex("dbo.Flights", new[] { "Departure_Id" });
            DropIndex("dbo.Flights", new[] { "Captain_CrewMemberId" });
            DropIndex("dbo.Flights", new[] { "Arriwal_Id" });
            DropIndex("dbo.FlightThreats", new[] { "ThreatType_Id" });
            DropIndex("dbo.FlightThreats", new[] { "ParentObservation_Id" });
            DropIndex("dbo.FlightObservations", new[] { "TakeOffPilot_CrewMemberId" });
            DropIndex("dbo.FlightObservations", new[] { "ObservedFlight_FlightId" });
            DropIndex("dbo.FlightObservations", new[] { "LandingPilot_CrewMemberId" });
            DropIndex("dbo.FlightObservations", new[] { "FlightObservingPerson_Id" });
            DropIndex("dbo.FlightErrors", new[] { "ParentObservation_Id" });
            DropIndex("dbo.FlightErrors", new[] { "ErrorType_Id" });
            DropIndex("dbo.FlightErrors", new[] { "DetectedBy_CrewMemberId" });
            DropIndex("dbo.FlightErrors", new[] { "CommitedBy_CrewMemberId" });
            DropIndex("dbo.CrewMembers", new[] { "PositionId_PositionId" });
            DropTable("dbo.EvaluationTakeOffs");
            DropTable("dbo.EvaluationPredepartures");
            DropTable("dbo.EvaluationLandings");
            DropTable("dbo.FlightCrews");
            DropTable("dbo.ErrorTypes");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
            DropTable("dbo.ThreatTypes");
            DropTable("dbo.FlightThreats");
            DropTable("dbo.Observers");
            DropTable("dbo.FlightObservations");
            DropTable("dbo.FlightErrors");
            DropTable("dbo.Positions");
            DropTable("dbo.CrewMembers");
            DropTable("dbo.Airports");
        }
    }
}
