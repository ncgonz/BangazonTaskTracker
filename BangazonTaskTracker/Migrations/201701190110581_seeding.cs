namespace BangazonTaskTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CompletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTasks");
        }
    }
}
