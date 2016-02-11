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

        public IList<JobDTO> ListJobs()
        {
            return (from j in _jobRepo.ListJobs()
                    select new JobDTO()
                    {
                        Id = j.Id,
                        Title = j.Title,
                        Description = j.Description,
                        Employer = (new EmployerDTO()
                        {
                            Id = j.Employer.Id,
                            FirstName = j.Employer.FirstName,
                            LastName = j.Employer.LastName
                        })
                    }).ToList();
        }

        public IList<JobDTO> SearchJobs(string searchTerm)
        {
            return (from j in _jobRepo.SearchJobs(searchTerm)
                    select new JobDTO()
                    {
                        Id = j.Id,
                        Title = j.Title,
                        Description = j.Description,
                        Employer = (new EmployerDTO()
                        {
                            Id = j.Employer.Id,
                            FirstName = j.Employer.FirstName,
                            LastName = j.Employer.LastName,
                            Company = (new CompanyDTO()
                            {
                                CompanyName = j.Employer.Company.CompanyName
                            })
                        })
                    }).ToList();
        }

        public JobDTO JobById(int id)
        {
            var jobToCopy = (_jobRepo.JobById(id));
            var jobToReturn = new JobDTO()
            {
                Id = jobToCopy.Id,
                Title = jobToCopy.Title,
                Description = jobToCopy.Description,
                Employer = (new EmployerDTO()
                {
                    Id = jobToCopy.Employer.Id,
                    FirstName = jobToCopy.Employer.FirstName,
                    LastName = jobToCopy.Employer.LastName,
                    Email = jobToCopy.Employer.Email,
                    PhoneNumber = jobToCopy.Employer.PhoneNumber,
                    Img = jobToCopy.Employer.Img,
                })
            };
            return jobToReturn;
        }
    }
}