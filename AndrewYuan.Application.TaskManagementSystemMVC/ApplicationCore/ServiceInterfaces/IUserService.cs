using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        public Task<List<UserCardResponseModel>> GetUsers();
        public Task<UserTasksResponseModel> GetTasks(int id);
        public Task<UserRegisterRequestModel> RegisterUser(UserRegisterRequestModel model);
        public Task DeleteUser(int id);
        public Task UpdateUser(UserRegisterRequestModel model);
    }
}
