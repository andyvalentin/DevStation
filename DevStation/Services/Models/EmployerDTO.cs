﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class EmployerDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CompanyDTO Company { get; set; }
        public JobDTO CurrentJob { get; set; }
        public IList<JobDTO> CompletedJobs { get; set; }
    }
}