namespace LOSA.DBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HireDate_to_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CrewMembers", "DismissalTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CrewMembers", "DismissalTime", c => c.DateTime(nullable: false));
        }
    }
}
