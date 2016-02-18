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
                        Description = j.Description.Substring(0, 50),
                        Employer = (new EmployerDTO()
                        {
                            FirstName = j.Employer.FirstName,
                            LastName = j.Employer.LastName, 
                            Img = j.Employer.Img
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
                            FirstName = j.Employer.FirstName,
                            LastName = j.Employer.LastName,
                            Img = j.Employer.Img,
                            Company = j.Employer.Company,
                            Position = j.Employer.Position
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
                    UserName = jobToCopy.Employer.UserName,
                    FirstName = jobToCopy.Employer.FirstName,
                    LastName = jobToCopy.Employer.LastName,
                    Email = jobToCopy.Employer.Email,
                    PhoneNumber = jobToCopy.Employer.PhoneNumber,
                    Img = jobToCopy.Employer.Img,
                    Position = jobToCopy.Employer.Position,
                    Company = jobToCopy.Employer.Company
                })
            };
            return jobToReturn;
        }
    }
}