using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class EmployerDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Img { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public IList<JobDTO> JobRequests { get; set; }
        public bool IsEmployer { get; set; }
    }
}