namespace BangazonTaskTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserTasks", "CompletedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTasks", "CompletedOn", c => c.DateTime(nullable: false));
        }
    }
}
