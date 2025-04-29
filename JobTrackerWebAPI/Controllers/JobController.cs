using JobTrackerWebAPI.Models;
using JobTrackerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class JobController : ControllerBase
    {
        private readonly JobService jobService;
        
        public JobController(JobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet] // Get all jobs
        public async Task<ActionResult<List<JobApplication>>> GetAllJobs()
        {
            var jobs = await jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("{id}")] // Get jobs by id
        public async Task<ActionResult<JobApplication>> GetById(Guid id)
        {
            var job = await jobService.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost] // Add job
        public async Task<ActionResult<JobApplication>> AddJob(JobApplication job)
        {
            await jobService.AddAsync(job);
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpPut] // Update Jobs
        public async Task<ActionResult> UpdateJob(Guid id, JobApplication updatedJob)
        {
            var result = await jobService.UpdateAsync(id, updatedJob);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // Delete Job
        public async Task<ActionResult> DeleteJob(Guid id)
        {
            var result = await jobService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }   
    }
}
