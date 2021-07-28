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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.ListAsync(u => u.Id == id);
            await _userRepository.DeleteAsync(user.First());
        }

        public async Task<UserTasksResponseModel> GetTasks(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var userTasks = new UserTasksResponseModel()
            {
                Fullname = user.Fullname, Id = user.Id
            };

            userTasks.myTasks = new List<Tasks>();
            userTasks.completedTasks = new List<TasksHistory>();
            foreach (var task in user.Tasks)
            {
                userTasks.myTasks.Add(new Tasks
                {
                    Id = task.Id, Description = task.Description, DueDate = task.DueDate, Priority = task.Priority, Remarks = task.Remarks, Title = task.Title
                });
            }
            foreach (var taskHistory in user.TasksHistories)
            {
                userTasks.completedTasks.Add(new TasksHistory
                {
                    TaskId = taskHistory.TaskId, Completed = taskHistory.Completed, Description = taskHistory.Description, DueDate = taskHistory.DueDate, Remarks = taskHistory.Remarks, Title = taskHistory.Title
                });
            }

            return userTasks;
        }

        public async Task<List<UserCardResponseModel>> GetUsers()
        {
            var myUsers = await _userRepository.GetUsers();

            var userCards = new List<UserCardResponseModel>();
            foreach (var user in myUsers)
            {
                userCards.Add(new UserCardResponseModel { Id = user.Id, Fullname = user.Fullname });
            }

            return userCards;
        }


        public async Task<UserRegisterRequestModel> RegisterUser(UserRegisterRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = new Users
            {
                Email = model.Email, Fullname = model.Fullname, Mobileno = model.Mobileno, Password = model.Password
            };
            var createdUser = await _userRepository.AddAsync(user);

            var userResponse = new UserRegisterRequestModel
            {
                Id = createdUser.Id, Email = createdUser.Email, Fullname = createdUser.Fullname, Mobileno = createdUser.Mobileno, Password = createdUser.Password
            };

            return(userResponse);
        }

        public async Task UpdateUser(UserRegisterRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                throw new Exception("User not Found");
            }
            var modUser = new Users
            {
                Id = user.Id,
                Email = user.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                Mobileno = model.Mobileno

            };
            await _userRepository.UpdateAsync(modUser);
        }
    }
}
