using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DevStation.Domain
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IActivatable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public IList<Message> Inbox { get; set; }
        public bool Active { get; set; } = true;
        public string Img { get; set; }
        public Company Company { get; set; }
        public IList<Job> JobRequests { get; set; }
        public Job CurrentJob { get; set; }
        public IList<Job> CompletedJobs { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}