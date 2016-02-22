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

            if (andy == null)
            {
                andy = new ApplicationUser
                {
                    UserName = "andyv",
                    Email = "andyv@gmail.com",
                    FirstName = "Andy",
                    LastName = "Valentin",
                    PhoneNumber = "(847) 666-6666",
                    Img = "http://www.almostsavvy.com/wp-content/uploads/2011/04/profile-photo.jpg",
                    Position = "CEO",
                    Company = "Coder Camps",
                    Active = true
                };

                userManager.Create(andy, "Secret123!");
                userManager.AddToRole(andy.Id, "Employer");
            }

            var employers = new ApplicationUser[1]
            {
                andy
            };
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
                    SkillSet = "Full Stack .Net, Javascript, C#, Typescript",
                    Img = "http://www.almostsavvy.com/wp-content/uploads/2011/04/profile-photo.jpg",
                    Position = "Junior Developer",
                    Active = true
                };

                userManager.Create(tony, "Secret123!");
                userManager.AddToRole(tony.Id, "Developer");
   
                
            }

            
            context.SaveChanges();
        }
    }
}
