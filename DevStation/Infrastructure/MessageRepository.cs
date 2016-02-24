using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevStation.Infrastructure
{
    public class MessageRepository
    {
        private ApplicationDbContext _db;

        public MessageRepository(DbContext db)
        {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<Message> MessageByUserName(string userName)
        {
            var messages = (from m in _db.Messages
                            where m.Active && m.To == userName
                            orderby m.DateCreated
                            select m);
            return messages;
        }

        public Message MessageById(int id)
        {
            var message = (from m in _db.Messages
                           where m.Active && m.Id == id
                           select m);
            return message.FirstOrDefault();
        }

        public void DeleteMessage(int id)
        {
            var messageToDelete = MessageById(id);
            messageToDelete.Active = false;
            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}