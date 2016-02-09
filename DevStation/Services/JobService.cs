using DevStation.Domain;
using DevStation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services
{
    public class JobService
    {
        private JobRepository _jobRepo;

        public JobService(JobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }

        public IList<Job> ListJobs()
        {
            return _jobRepo.List().ToList();
        }
    }
}