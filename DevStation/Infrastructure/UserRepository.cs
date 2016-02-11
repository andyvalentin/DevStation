using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevStation.Infrastructure
{
    public class UserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(DbContext db)
        {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<ApplicationUser> ListUsers()
        {
            return from u in _db.Users
                   where u.Active
                   select u;
        }
    }
}