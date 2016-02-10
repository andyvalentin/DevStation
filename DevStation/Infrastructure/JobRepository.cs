using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevStation.Infrastructure
{
    public class JobRepository
    {
        private ApplicationDbContext _db;

        public JobRepository(DbContext db)
        {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<Job> ListJobs()
        {
            return from j in _db.Jobs
                   where j.Active
                   select j;
        }

        public IQueryable<Job> SearchJobs(string searchTerm)
        {
            return from j in _db.Jobs
                   where j.Active &&
                   (j.Title.Contains(searchTerm) ||
                   j.Description.Contains(searchTerm) ||
                   j.Employer.FirstName.Contains(searchTerm)) ||
                   j.Employer.Company.CompanyName.Contains(searchTerm)
                   select j;
        }

    }
}