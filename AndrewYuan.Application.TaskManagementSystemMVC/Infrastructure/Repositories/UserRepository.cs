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
    public class UserRepository : EfRepository<Users>, IUserRepository
    {
        public UserRepository(TaskManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Users>> GetUsers()
        {
            var myUsers = await _dbContext.Users.OrderByDescending(u => u.Id).ToListAsync();
            return myUsers;
        }

        public override async Task<Users> GetByIdAsync(int id)
        {
            var myUsers = await _dbContext.Users.Include(navigationPropertyPath: u => u.Tasks).Include(u=>u.TasksHistories).FirstOrDefaultAsync(u=>u.Id == id);
            if (myUsers == null)
            {
                throw new Exception($"no user found with {id}");
            }
            return myUsers;
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

    }
}
