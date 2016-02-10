namespace DevStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        Active = c.Boolean(nullable: false),
                        Img = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Company_Id = c.Int(),
                        CurrentJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.Jobs", t => t.CurrentJob_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Company_Id)
                .Index(t => t.CurrentJob_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Employer_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Employer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.Employer_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        To = c.String(),
                        From = c.String(),
                        Body = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Employers_Id = c.String(maxLength: 128),
                        Developer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Employers_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Developer_Id)
                .Index(t => t.Employers_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CurrentJob_Id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Developer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "Employers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "Developer_Id" });
            DropIndex("dbo.Jobs", new[] { "Employers_Id" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Jobs", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Jobs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Jobs", new[] { "Employer_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CurrentJob_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Messages");
            DropTable("dbo.Jobs");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
        }
    }
}
