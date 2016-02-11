namespace DevStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SkillSet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SkillSet");
        }
    }
}
