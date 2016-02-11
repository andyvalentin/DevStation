using DevStation.Infrastructure;
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
    public class JobsController : ApiController
    {
        private JobService _jobService;

        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [Route("api/jobs/search/{searchTerm}")]
        public IList<JobDTO> JobSearch(string searchTerm)
        {
            return _jobService.SearchJobs(searchTerm).ToList();
        }

        [HttpGet]
        [Route("api/jobs/list")]
        public IHttpActionResult listJobs()
        {
            if(ModelState.IsValid)
            {
                return Ok(_jobService.ListJobs());
            }
            return BadRequest("This is a bad request");
        }
    }
}
