namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTableLop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "SubjectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Class", "SubjectId");
        }
    }
}
