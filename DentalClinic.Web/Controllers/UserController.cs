using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static DentalClinicSystem.Common.NotificationMessagesConstants;

namespace DentalClinicSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                return BadRequest("This role is alredy exist!");
            }
            var role = new IdentityRole(roleName);

            var result = await _roleManager.CreateAsync(role);

            return Ok(result);
        }


        public async Task<IActionResult> MakeAdmin(string email)
        {

            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, "Admin");

            return Ok(result);

        }
        [HttpGet]
        public IActionResult MakeDentist()
        {
            var model = new MakeDentistViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeDentist(MakeDentistViewModel model)
        {

            var role = await _roleManager.RoleExistsAsync("Dentist");
            if (!role)
            {
                return BadRequest("this role does not exist");
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, "Dentist");
            if (result.Succeeded)
            {
                TempData[SuccessMessage] = $"Successfully created Dentist: {user.Email}";
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult RemoveDentist()
        {
            var model = new MakeDentistViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDentist(MakeDentistViewModel model)
        {

            var role = await _roleManager.RoleExistsAsync("Dentist");
            if (!role)
            {
                return BadRequest("this role does not exist");
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "Dentist");
            if (result.Succeeded)
            {
                TempData[WarningMessage] = $"Successfully removed Dentist: {user.Email}";
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
