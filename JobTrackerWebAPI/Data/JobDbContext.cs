using JobTrackerWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerWebAPI.Data
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
