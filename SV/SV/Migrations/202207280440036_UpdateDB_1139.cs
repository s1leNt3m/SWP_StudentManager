namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB_1139 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSchedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LopId = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                        Session = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Class", "SheduleOject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Class", "SheduleOject", c => c.String());
            DropTable("dbo.ClassSchedule");
        }
    }
}
