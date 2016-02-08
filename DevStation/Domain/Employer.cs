using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Domain
{
    public class Employer : ApplicationUser
    {
        public Company Company { get; set; }
        public IList<Job> JobRequests { get; set; }
    }
}