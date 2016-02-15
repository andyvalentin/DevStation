namespace DevStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id" });
            AddColumn("dbo.AspNetUsers", "Company", c => c.String());
            DropColumn("dbo.AspNetUsers", "Company_Id");
            DropTable("dbo.Companies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyEmail = c.String(),
                        CompanyPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Company_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Company");
            CreateIndex("dbo.AspNetUsers", "Company_Id");
            AddForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
