using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Domain
{
    public class Developer : ApplicationUser
    {
        public Job CurrentJob { get; set; }
        public IList<Job> CompletedJobs { get; set; }
    }
}