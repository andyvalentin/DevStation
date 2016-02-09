using DevStation.Domain;
using DevStation.Infrastructure;
using DevStation.Services.Models;
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

        public IList<JobDTO> Search(string searchTerm)
        {
            return (from j in _jobRepo.List()
                    where j.Active &&
                    j.Description.Contains(searchTerm) ||
                    j.Employers.Company.CompanyName.StartsWith(searchTerm)
                    select new JobDTO() {
                        Id = j.Id,
                        Description = j.Description,
                        Company = j.Employers.Company.CompanyName
                    }).ToList();
        }
    }
}