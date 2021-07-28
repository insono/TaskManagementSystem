using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITasksService
    {
        public Task<List<TasksResponseModel>> GetTasks();
        public Task<TasksResponseModel> AddTask(TasksRequestModel model);
        public Task DeleteTask(int id);
    }
}
