using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Contracts.V1;
using TaskTracker.Contracts.V1.Requests;
using TaskTracker.Contracts.V1.Response;
using TaskTracker.Domain;

namespace TaskTracker.Controllers.V1
{
    public class JobController : Controller
    {
        private readonly List<Job> _Jobs;

        public JobController()
        {
            _Jobs = new List<Job>();
            for (int i = 0; i < 5; i++)
            {
                _Jobs.Add(new Job 
                { 
                    Id = Guid.NewGuid(),
                    Name = $"Job Name {i}"
                });
            }
        }
        [HttpGet(ApiRoutes.Jobs.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_Jobs);
        }

        [HttpGet(ApiRoutes.Jobs.Get)]
        public IActionResult Get([FromRoute]Guid jobId)
        {
            var job = _Jobs.SingleOrDefault(x => x.Id == jobId);

            if(job == null)
            {
                return NotFound();
            }
            return Ok(_Jobs);
        }

        [HttpPost(ApiRoutes.Jobs.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var job = new Job { Id = postRequest.Id };
            if (job.Id != Guid.Empty)
            {
                job.Id = Guid.NewGuid();
            }

            _Jobs.Add(job);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Jobs.Get.Replace("{jobId}",job.Id.ToString());

            var reponse = new PostResponse { Id = postRequest.Id };
            return Created(locationUrl, job);
        }
    }
}
