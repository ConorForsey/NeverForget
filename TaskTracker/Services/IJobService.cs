using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Domain;

namespace TaskTracker.Services
{
    public interface IJobService
    {
        Task<List<Job>> GetJobsAsync();

        Task<Job> GetJobByIdAsync(Guid jobId);

        Task<bool> UpdateJobAsync(Job jobToUpdate);

        Task<bool> DeleteJobAsync(Guid jobId);

        Task<bool> CreateJobAsync(Job job);
    }
}
