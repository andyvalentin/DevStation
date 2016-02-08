using DevStation.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevStation.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<Developer> Developers { get; set; }
        public IDbSet<Employer> Employers { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}