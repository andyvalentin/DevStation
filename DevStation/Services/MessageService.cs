using DevStation.Domain;
using DevStation.Infrastructure;
using DevStation.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services
{
    public class MessageService
    {
        private MessageRepository _messageRepo;
        private UserRepository _userRepo;

        public MessageService(MessageRepository messageRepo, UserRepository userRepo)
        {
            _messageRepo = messageRepo;
            _userRepo = userRepo;
        }

        public IList<MessageDTO> CurrentUserMessages(string userName)
        {
            var messages = (from m in _messageRepo.MessageByUserName(userName)
                            select new MessageDTO()
                            {
                                Id = m.Id,
                                To = m.To,
                                From = m.From,
                                Body = m.Body, 
                                DateCreated = m.DateCreated
                            });
            return messages.ToList();
        }

        public void Send(Message messageSent, string from)
        {
            var user = _userRepo.UserByUserName(messageSent.To);
            var message = new Message()
            {
                To = messageSent.To,
                From = from, 
                Body = messageSent.Body,
                Active = true
            };

            user.Inbox.Add(message);
            _userRepo.SaveChanges();
        }

    }
}