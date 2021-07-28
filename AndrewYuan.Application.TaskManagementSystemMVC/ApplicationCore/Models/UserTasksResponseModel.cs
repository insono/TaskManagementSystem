using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserTasksResponseModel
    {
        public int Id;
        public string Fullname;
        public List<Tasks> myTasks;
        public List<TasksHistory> completedTasks;
    }
}
