using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public JobDTO CurrentJob { get; set; }
        public IList<JobDTO> CompletedJobs { get; set; }
        public string Img { get; set; }
    }
}