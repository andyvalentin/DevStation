using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services.Models
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
        [JsonIgnore]
        public IList<EmployerDTO> Employers { get; set; }
    }
}