using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
    }
}