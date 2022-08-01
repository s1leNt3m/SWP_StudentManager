namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB29072022V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        PointStudy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointGK = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointCK = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            DropTable("dbo.UserPoint");
        }
    }
}
