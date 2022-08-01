namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB29072022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Class", "Code");
        }
    }
}
