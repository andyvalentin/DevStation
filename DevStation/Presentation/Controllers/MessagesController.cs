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
    public class MessagesController : ApiController
    {
        private MessageService _messageService;
        private UserService _userService;

        public MessagesController(MessageService messageService, UserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("api/messages/currentUser")]
        public IHttpActionResult CurrentUserMessages()
        {
            if(ModelState.IsValid)
            {
                var messages = _messageService.CurrentUserMessages(User.Identity.Name);
                return Ok(messages);
            }
            return BadRequest("Could not return messages");
        }

        [HttpPost]
        [Authorize]
        [Route("api/messages/send")]
        public IHttpActionResult SendMessage(Message messageSent)
        {
            if(messageSent != null)
            {
                if (ModelState.IsValid)
                {
                    _messageService.Send(messageSent, User.Identity.Name);
                    return Ok("Message was sent successfully");
                }
                return BadRequest("Message was not sent");
            }
            return BadRequest();
        }

        //try to figure out if u have time
        [HttpDelete]
        [Authorize]
        [Route("api/messages/deleteMany")]
        public IHttpActionResult DeleteMany(int[] messagesToDelete)
        {
            return null;
        }

        [HttpDelete]
        [Authorize]
        [Route("api/messages/deleteOne/{id}")]
        public IHttpActionResult DeleteMessage(int id)
        {
            if(ModelState.IsValid)
            {
                _messageService.DeleteOne(id);
                return Ok();
            }
            return BadRequest("Could not find message");
        }

        [HttpGet]
        [Authorize]
        [Route("api/messages/user/{searchTerm}")]
        public IList<DeveloperDTO> SearchUserNames(string searchTerm)
        {
            var listToReturn = _userService.SearchUserNames(searchTerm);
            return listToReturn;
        }

    }
}
