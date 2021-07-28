using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            if (!users.Any())
            {
                return NotFound("No Users Found");
            }

            return Ok(users);
        }

        public async Task<IActionResult> AddUser([FromBody] UserRegisterRequestModel model)
        {
            var createdUser = await _userService.RegisterUser(model);

            return Ok(createdUser);
        }
    }
}
