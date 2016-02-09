using DevStation.Domain;
using DevStation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services
{
    public class UserService
    {
        private UserRepository _userRepo;

        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public IList<ApplicationUser> ListUser()
        {
            return (_userRepo.ListUsers()).ToList();
        }
    }
}