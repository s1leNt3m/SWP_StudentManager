namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnTableUserLop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLop", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.UserLop", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLop", "SubjectId", c => c.Int(nullable: false));
            DropColumn("dbo.UserLop", "UserId");
        }
    }
}
