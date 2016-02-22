using DevStation.Domain;
using DevStation.Services;
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

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
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
            if(ModelState.IsValid)
            {
                 _messageService.Send(messageSent, User.Identity.Name);
                return Ok("Message was sent successfully");
            }
            return BadRequest("Message was not sent");
        }
    }
}
