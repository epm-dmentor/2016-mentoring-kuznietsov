namespace LOSA.DBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable_fields_added_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "CurrentFlightAttitude", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "CurrentFlightAttitude", c => c.Int(nullable: false));
        }
    }
}
