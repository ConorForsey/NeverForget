using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Domain;

namespace TaskTracker.Services
{
    public class JobService : IJobService
    {
        private readonly DataContext _dataContext;

        public JobService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeleteJobAsync(Guid jobId)
        {
            var job = await GetJobByIdAsync(jobId);

            if (job == null)
            {
                return false;
            }

            _dataContext.Jobs.Remove(job);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Job> GetJobByIdAsync(Guid jobId)
        {
            return await _dataContext.Jobs.SingleOrDefaultAsync(x => x.Id == jobId);
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            return await _dataContext.Jobs.ToListAsync();
        }

        public async Task<bool> UpdateJobAsync(Job jobToUpdate)
        {
            _dataContext.Jobs.Update(jobToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> CreateJobAsync(Job job)
        {
            await _dataContext.Jobs.AddAsync(job);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
