namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB_1139V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduleEntities");
        }
    }
}
