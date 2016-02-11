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
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var tony = userManager.FindByName("tonyc");

            if(tony == null)
            {
                tony = new ApplicationUser
                {
                    UserName = "tonyc",
                    Email = "tonyc@gmail.com",
                    FirstName = "Tony",
                    LastName = "Chabi",
                    PhoneNumber = "(847) 999-9999"
                };

                userManager.Create(tony, "Secret123!");
            }

            var andy = userManager.FindByName("andyv");

            if(andy == null)
            {
                andy = new ApplicationUser
                {
                    UserName = "andyv",
                    Email = "andyv@gmail.com",
                    FirstName = "Andy",
                    LastName = "Valentin",
                    PhoneNumber = "(847) 666-6666"
                };
                userManager.Create(andy, "Secret123!");
            }

            var employers = new ApplicationUser[2]
            {
                andy,
                tony
            };

            var jobs = new Job[]
            {
                new Job { Title = "Group Project", Description = "Need to finish to graduate", Active = true, Employer = tony },
                new Job { Title = "Bug Catcher", Description = "Catch bugs in the code", Active = true, Employer = andy },
                new Job { Title = "Detailer", Description = "Put chips on shelves", Employer = tony, Active = true },
                new Job { Title = "Programmer", Description = "Write full CRUD wep api apps", Active = true, Employer = andy }
            };

            var companies = new Company[]
            {
                new Company { CompanyName = "Coder Camps", CompanyEmail = "codecamps@gmail.com", Employers = employers },
                new Company { CompanyName = "Frito Lay", CompanyEmail = "fritolay@gamil.com", Employers = employers  },
                new Company { CompanyName = "Hersheys", CompanyEmail = "hersheys@gmail.com" }
            };

            context.Jobs.AddOrUpdate(u => u.Title, jobs);
            context.Companies.AddOrUpdate(c => c.CompanyName, companies);

            
            if (context.Roles.Count() == 0)
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var developer = new IdentityRole { Name = "Developer" };
                var employer = new IdentityRole { Name = "Employer" };

                manager.Create(developer);
                manager.Create(employer);
            }

        }
    }
}
