using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystemMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Tasks(int id)
        {
            var userTasks = await _userService.GetTasks(id);
            return View(userTasks);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var createdUser = await _userService.RegisterUser(model);

            return View("Done");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserCardResponseModel model)
        {
            await _userService.DeleteUser(model.Id);
            return View("Done");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _userService.UpdateUser(model);

            return View("Done");
        }
    }
}
