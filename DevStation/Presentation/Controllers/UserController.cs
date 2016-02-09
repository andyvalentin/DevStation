using DevStation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStation.Presentation.Controllers
{
    public class UserController : ApiController
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
    }
}
