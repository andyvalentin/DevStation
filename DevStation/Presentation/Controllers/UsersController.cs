﻿using DevStation.Domain;
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

        public UsersController(UserService userService, JobService jobService)
        {
            _userService = userService;
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
    }
}
