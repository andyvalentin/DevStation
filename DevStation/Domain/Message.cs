using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStation.Domain
{
    public class Message : IActivatable
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool Active { get; set; }
    }
}