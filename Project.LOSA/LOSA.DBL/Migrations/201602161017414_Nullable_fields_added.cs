namespace LOSA.DBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable_fields_added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "TakeOffTimeStamp", c => c.DateTime());
            AlterColumn("dbo.Flights", "LandingTimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "LandingTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Flights", "TakeOffTimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
