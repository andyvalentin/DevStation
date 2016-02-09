using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevStation.Infrastructure
{
    public class JobRepository : GenericRepository<Job>
    {
        public JobRepository(DbContext db) : base(db) { }
    }
}