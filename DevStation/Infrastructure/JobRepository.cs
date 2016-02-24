using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            var jobs = _db.Jobs
                .Include(j => j.Employer);
            return jobs;
        }

        public IQueryable<Job> SearchJobs(string searchTerm)
        {
            return (from j in _db.Jobs
                   where j.Active &&
                   j.Title.Contains(searchTerm) ||
                   j.Description.Contains(searchTerm) ||
                   j.Employer.FirstName.Contains(searchTerm) ||
                   j.Employer.LastName.Contains(searchTerm)
                   select j);
        }

        public Job JobById(int id)
        {
            return (from j in _db.Jobs
                   where j.Complete == false && j.Id == id
                   select j)
                   .Include(j => j.Employer)
                   .FirstOrDefault();
        }

        public void AddJob(Job jobToAdd)
        {
            _db.Jobs.Add(jobToAdd);
            _db.SaveChanges();
        }
    }
}