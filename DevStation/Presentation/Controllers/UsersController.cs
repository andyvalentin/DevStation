using DevStation.Domain;
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
        [Authorize]
        [Route("api/users/profile")]
        public IHttpActionResult UserByUserName()
        {
            if (ModelState.IsValid)
            {
                var userToReturn = _userService.UserByUserName(User.Identity.Name);
                return Ok(userToReturn);
            }
            return BadRequest("User could not be found");
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/employerProfile")]
        public IHttpActionResult EmployerByUserName()
        {
            if(ModelState.IsValid)
            {
                var userToReturn = _userService.EmployerByUserName(User.Identity.Name);
                return Ok(userToReturn);
            }
            return BadRequest("Employer could not be found");
        }

        [HttpPost]
        [Authorize]
        [Route("api/user/profile/edit")]
        public IHttpActionResult UpdateUserProfile(ApplicationUser user) {
            if (ModelState.IsValid) {
                _userService.UpdateDevProfile(user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.SkillSet, User.Identity.Name);

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        [Route("api/user/employerprofile/edit")]
        public IHttpActionResult UpdateEmployerProfile(ApplicationUser employer)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateEmployerProfile(employer, User.Identity.Name);
                return Ok();
            }
            return BadRequest("Current Employer was not edited");
        }

        [HttpGet]
        [Authorize]
        [Route("api/devs/list")]
        public IHttpActionResult AllDevList() {
            if (ModelState.IsValid) {

                return Ok(_userService.AllDevList());
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        [Route("api/devs/search/{searchTerm}")]
        public IHttpActionResult SearchDevs(string searchTerm)
        {
            if (ModelState.IsValid) {
                return Ok(_userService.SearchDevs(searchTerm));
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        [Route("api/dev/acceptjob")]
        public IHttpActionResult DevAcceptJob(Job job)
        {
            if (ModelState.IsValid)
            {
                _userService.DevAcceptJob(job.Id, User.Identity.Name);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/completeJob/{id}")]
        public IHttpActionResult CompleteJob(int id)
        {
            if (ModelState.IsValid)
            {
                _userService.FinishJob(id, User.Identity.Name);
                return Ok();
            }
            return BadRequest();
        }
    }
}
