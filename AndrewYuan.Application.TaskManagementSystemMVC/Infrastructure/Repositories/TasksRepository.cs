using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TasksRepository : EfRepository<Tasks>, ITasksRepository
    {
        public TasksRepository(TaskManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var tasks = await _dbContext.Tasks.OrderByDescending(t => t.Id).ToListAsync();
            return tasks;
        }

        public async Task<List<Tasks>> GetTasksById(int id)
        {
            var tasks = await _dbContext.Tasks.Where(t => t.Id == id).ToListAsync();
            return tasks;
        }
    }
}
