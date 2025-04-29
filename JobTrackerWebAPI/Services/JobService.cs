using JobTrackerWebAPI.Data;
using JobTrackerWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerWebAPI.Services
{
    public class JobService
    {
        private readonly JobDbContext jobs;

        public JobService(JobDbContext jobDbContext)
        {
            this.jobs = jobDbContext;
        }

        // Get all jobs
        public async Task<List<JobApplication>> GetAllJobs()
        {
            return await jobs.JobApplications.ToListAsync();
        }

        // Get job by id
        public async Task<JobApplication> GetById(Guid id)
        {
            return await jobs.JobApplications.FindAsync(id);
        }

        // Add job
        public async Task AddAsync(JobApplication job)
        {
            job.Id = Guid.NewGuid();
            await jobs.JobApplications.AddAsync(job);
            await jobs.SaveChangesAsync();
        }

        // Update jobs
        public async Task<bool> UpdateAsync(Guid id, JobApplication updatedJob)
        {
            var existingJob = await jobs.JobApplications.FindAsync(id);
            if (existingJob == null)
            {
                return false;
            }
            existingJob.CompanyName = updatedJob.CompanyName;
            existingJob.Position = updatedJob.Position;
            existingJob.Status = updatedJob.Status;
            existingJob.Location = updatedJob.Location;
            existingJob.DateApplied = updatedJob.DateApplied;
            existingJob.DateInterviewed = updatedJob.DateInterviewed;
            existingJob.Notes = updatedJob.Notes;
            await jobs.SaveChangesAsync();
            return true;
        }

        // Delete jobs
        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingJob = await jobs.JobApplications.FindAsync(id);
            if (existingJob == null)
            {
                return false;
            }
            jobs.JobApplications.Remove(existingJob);
            await jobs.SaveChangesAsync();
            return true;
        }
    }
}
