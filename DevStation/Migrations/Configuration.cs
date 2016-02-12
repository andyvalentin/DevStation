namespace DevStation.Migrations
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Services.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevStation.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DevStation.Infrastructure.ApplicationDbContext context)
        {
            if (context.Roles.Count() == 0)
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var developer = new IdentityRole { Name = "Developer" };
                var employer = new IdentityRole { Name = "Employer" };

                manager.Create(developer);
                manager.Create(employer);
            }
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);


            

            ApplicationUser andy = userManager.FindByName("andyv");

            if(andy == null)
            {
                andy = new ApplicationUser
                {
                    UserName = "andyv",
                    Email = "andyv@gmail.com",
                    FirstName = "Andy",
                    LastName = "Valentin",
                    PhoneNumber = "(847) 666-6666",
                    Active = true
                };
                userManager.Create(andy, "Secret123!");
                userManager.AddToRole(andy.Id, "Employer");

            }

            var employers = new ApplicationUser[1]
            {
                andy
            };

            var group = new Job { Id = 1, Title = "Group Project", Description = "Need to finish to graduate", Active = true, Employer = andy };
            var catcher = new Job { Id = 2, Title = "Bug Catcher", Description = "Catch bugs in the code", Active = true, Employer = andy };
            var frito = new Job { Id = 3, Title = "Detailer", Description = "Put chips on shelves", Employer = andy, Active = true };
            var programmer = new Job { Id = 4, Title = "Programmer", Description = "Write full CRUD wep api apps", Active = true, Employer = andy };

            var jobs = new Job[]
            {
                group,
                catcher,
                frito,
                programmer                
            };

            context.Jobs.AddOrUpdate(u => u.Title, jobs);
            context.SaveChanges();

            var tony = userManager.FindByName("tonyc");
            if (tony == null)
            {
                tony = new ApplicationUser
                {
                    UserName = "tonyc",
                    Email = "tonyc@gmail.com",
                    FirstName = "Tony",
                    LastName = "Chabi",
                    PhoneNumber = "(847) 999-9999",
                    CurrentJob = programmer,
                    SkillSet = "Full Stack .Net, Javascript, C#, Typescript",
                    CompletedJobs = new Job[] { frito, group },
                    Active = true
                };

                userManager.Create(tony, "Secret123!");
                userManager.AddToRole(tony.Id, "Developer");
   
                
            }

            var companies = new Company[]
            {
                new Company { CompanyName = "Coder Camps", CompanyEmail = "codecamps@gmail.com" },
                new Company { CompanyName = "Frito Lay", CompanyEmail = "fritolay@gamil.com"  },
                new Company { CompanyName = "Hersheys", CompanyEmail = "hersheys@gmail.com" }
            };

            
            context.Companies.AddOrUpdate(c => c.CompanyName, companies);
            context.SaveChanges();
        }
    }
}
