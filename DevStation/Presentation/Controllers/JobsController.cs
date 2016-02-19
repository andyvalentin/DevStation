using DevStation.Domain;
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
        [Authorize]
        [Route("api/jobs/search/{searchTerm}")]
        public IList<JobDTO> JobSearch(string searchTerm)
        {
            return _jobService.SearchJobs(searchTerm).ToList();
        }

        [HttpGet]
        [Authorize]
        [Route("api/jobs/list")]
        public IHttpActionResult ListJobs()
        {
            if(ModelState.IsValid)
            {
                return Ok(_jobService.ListJobs());
            }
            return BadRequest("This is a bad request");
        }

        [HttpGet]
        [Authorize]
        [Route("api/jobs/{id}")]
        public IHttpActionResult JobById(int id)
        {
            if(ModelState.IsValid)
            {
                var gameToReturn = _jobService.JobById(id);
                return Ok(_jobService.JobById(id));
            }
            return BadRequest("JobById yielded no results");
        }

        [HttpPost]
        [Authorize]
        [Route("api/jobs/add")]
        public IHttpActionResult AddJob(Job jobToAdd)
        {
            if(ModelState.IsValid)
            {
                _jobService.AddJobAsEmployer(User.Identity.Name, jobToAdd.Title, jobToAdd.Description);
                return Ok();
            }
            return BadRequest("Could not add the game");
        }
    }
}
