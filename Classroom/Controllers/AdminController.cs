using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.Interfaces;
using Classroom.Models;
using Classroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository userRepository;
     
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var usersViewModel = new UsersViewModel
            {
                Users = userManager.Users
            };
            return View(usersViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = createUserViewModel.Email,
                Email = createUserViewModel.Email
            };
            var result = await userManager.CreateAsync(user, createUserViewModel.Password);
            if (result.Succeeded)
            {
                var createdUser = await userManager.FindByEmailAsync(createUserViewModel.Email);
                if (await roleManager.FindByNameAsync(createUserViewModel.Role) == null)
                {
                    var role = new IdentityRole(createUserViewModel.Role);
                    await roleManager.CreateAsync(role);
                    await userManager.AddToRoleAsync(createdUser, role.Name);
                }
                else
                {
                    await userManager.AddToRoleAsync(createdUser, createUserViewModel.Role);
                }
                var userToCreate = new User
                {
                    Email = createUserViewModel.Email,
                    UserId = user.Id
                };
                userRepository.Add(userToCreate);
            }
            return RedirectToAction("Index");
        }
        
    }
}