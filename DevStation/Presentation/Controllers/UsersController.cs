using DevStation.Services;
using DevStation.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStation.Presentation.Controllers
{
    public class UsersController : ApiController
    {
        private UserService _userService;
        private JobService _jobService;

        public UsersController(UserService userService, JobService jobService)
        {
            _userService = userService;
            _jobService = jobService;
        }

        [HttpGet]
        [Route("api/users/search/${searchTerm}")]
        public IList<JobDTO> JobSearch(string searchTerm)
        {
            return _jobService.Search(searchTerm);
        }
    }
}
