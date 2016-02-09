namespace DevStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Title");
        }
    }
}
