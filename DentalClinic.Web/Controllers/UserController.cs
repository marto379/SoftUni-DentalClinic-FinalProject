using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeDentist(string email)
        {
            var role = await _roleManager.RoleExistsAsync("Dentist");
            if (!role)
            {
                return BadRequest("this role does not exist");
            }

            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, "Dentist");

            return Ok(result);

        }

    }
}
