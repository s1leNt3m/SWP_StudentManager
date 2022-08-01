namespace SV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSheduleOject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "SheduleOject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Class", "SheduleOject");
        }
    }
}
