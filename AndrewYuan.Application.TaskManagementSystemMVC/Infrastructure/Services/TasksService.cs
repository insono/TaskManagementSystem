using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task<TasksResponseModel> AddTask(TasksRequestModel model)
        {
            var newTask = new Tasks
            {
                UserId = model.UserId,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks,
                Title = model.Title
            };


            var dbTask = await _tasksRepository.AddAsync(newTask);
            var tasksModel = new TasksResponseModel
            {
                Id = dbTask.Id,
                UserId = model.UserId,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks,
                Title = model.Title
            };

            return tasksModel;
        }

        public async Task DeleteTask(int id)
        {
            var task = await _tasksRepository.ListAsync(t => t.Id == id);
            await _tasksRepository.DeleteAsync(task.First());
        }

        public async Task<List<TasksResponseModel>> GetTasks()
        {
            var tasks = await _tasksRepository.GetTasks();
            var tasksModels = new List<TasksResponseModel>();
            foreach (var task in tasks)
            {
                tasksModels.Add(new TasksResponseModel
                {
                    UserId = task.UserId, Description = task.Description, DueDate = task.DueDate, Priority = task.Priority, Title = task.Title, Remarks = task.Remarks
                });
            }

            return tasksModels;
        }
    }
}
