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


            

            ApplicationUser andrew = userManager.FindByName("andrew");

            if (andrew == null)
            {
                andrew = new ApplicationUser
                {
                    UserName = "andrewg",
                    Email = "andrew@gmail.com",
                    FirstName = "Andrew",
                    LastName = "Garcia",
                    PhoneNumber = "(847) 666-6666",
                    Img = "http://andyvalentine.co.uk/img/andyvalentine-profile-dec15.jpg",
                    Position = "CEO",
                    Company = "Windy City Design",
                    Active = true
                };

                userManager.Create(andrew, "Secret123!");
                userManager.AddToRole(andrew.Id, "Employer");
            }


            ApplicationUser bill = userManager.FindByName("billg");

            if (bill == null)
            {
                bill = new ApplicationUser
                {
                    UserName = "billg",
                    Email = "billgates@gmail.com",
                    FirstName = "Bill",
                    LastName = "Gates",
                    PhoneNumber = "(312) 555-1758",
                    Img = "http://aib.edu.au/blog/wp-content/uploads/2015/08/bill-gates-jpg.jpg",
                    Position = "CEO",
                    Company = "Microsoft",
                    Active = true
                };

                userManager.Create(bill, "Secret123!");
                userManager.AddToRole(bill.Id, "Employer");
            }

            ApplicationUser steve = userManager.FindByName("steveb");

            if (steve == null)
            {
                steve = new ApplicationUser
                {
                    UserName = "steveb",
                    Email = "steveballmers@gmail.com",
                    FirstName = "Steve",
                    LastName = "Balmer",
                    PhoneNumber = "(801) 759-38472",
                    Img = "http://betanews.com/wp-content/uploads/2013/07/Steve-Ballmer-e1377267783187.jpg",
                    Position = "Owner",
                    Company = "LA Clippers",
                    Active = true
                };

                userManager.Create(steve, "Secret123!");
                userManager.AddToRole(steve.Id, "Employer");
            }


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
                    Img = "https://scontent-yyz1-1.xx.fbcdn.net/hphotos-xta1/v/t1.0-9/12108075_10206958785555801_3661604727733037590_n.jpg?oh=5a7bfffb6a93bb391190a7cb3d4951ef&oe=5759B9F0",
                    Position = "Junior Developer",
                    Active = true
                };

                userManager.Create(tony, "Secret123!");
                userManager.AddToRole(tony.Id, "Developer");
                
            }

            var andy = userManager.FindByName("andyv");
            if (andy == null)
            {
                andy = new ApplicationUser
                {
                    UserName = "andyv",
                    Email = "andyv@gmail.com",
                    FirstName = "Andy",
                    LastName = "Valentin",
                    PhoneNumber = "(312) 684-5749",
                    SkillSet = "Full Stack .Net, Javascript, C#, Typescript",
                    Img = "http://gtkglobal.com/wp-content/uploads/2016/02/nikola-tesla-1.jpg",
                    Position = "Junior Developer",
                    Active = true
                };

                userManager.Create(andy, "Secret123!");
                userManager.AddToRole(andy.Id, "Developer");
            }

            var woz = userManager.FindByName("thewoz");
            if (woz == null)
            {
                woz = new ApplicationUser
                {
                    UserName = "thewoz",
                    Email = "WizarOfWoz@gmail.com",
                    FirstName = "Steve",
                    LastName = "Wozniak",
                    PhoneNumber = "(312) 684-5749",
                    SkillSet = "I am the all powerful Woz.  I can do anything with any operating system on any device.",
                    Img = "http://audioxpress.com/assets/upload/images/Steve_WozniakWeb.jpg",
                    Position = "Junior Developer",
                    Active = true
                };

                userManager.Create(woz, "Secret123!");
                userManager.AddToRole(woz.Id, "Developer");
            }

            context.SaveChanges();
        }
    }
}
