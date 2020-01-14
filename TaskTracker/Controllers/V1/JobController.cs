using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Contracts.V1;
using TaskTracker.Contracts.V1.Requests;
using TaskTracker.Contracts.V1.Response;
using TaskTracker.Domain;
using TaskTracker.Services;

namespace TaskTracker.Controllers.V1
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet(ApiRoutes.Jobs.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobService.GetJobsAsync());
        }

        [HttpGet(ApiRoutes.Jobs.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid jobId)
        {
            var job = await _jobService.GetJobByIdAsync(jobId);

            if(job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost(ApiRoutes.Jobs.Create)]
        public async Task<IActionResult> Create([FromBody] CreateJobRequest jobRequest)
        {
            var job = new Job { Name = jobRequest.Name };

            await _jobService.CreateJobAsync(job);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Jobs.Get.Replace("{jobId}",job.Id.ToString());

            var reponse = new PostResponse { Id = job.Id };
            return Created(locationUrl, job);
        }

        [HttpPut(ApiRoutes.Jobs.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid jobId, [FromBody]UpdateJobRequest request)
        {
            var job = new Job 
            { 
                Id = jobId, 
                Name = request.Name 
            };

            var updated = await _jobService.UpdateJobAsync(job);

            if (updated)
            {
                return Ok(job);
            }
            else return NotFound();
        }

        [HttpDelete(ApiRoutes.Jobs.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid jobId)
        {
            var deleted = await _jobService.DeleteJobAsync(jobId);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
