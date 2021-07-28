using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ITasksRepository:IAsyncRepository<Tasks>
    {
        Task<List<Tasks>> GetTasks();
        Task<List<Tasks>> GetTasksById(int id);
    }
}
