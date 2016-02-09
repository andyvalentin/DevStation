using DevStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
    }
}