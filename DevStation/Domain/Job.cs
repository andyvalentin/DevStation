using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStation.Domain
{
    public class Job : IActivatable, IDbEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser Employer { get; set; }
        public bool Active { get; set; }
    }
}