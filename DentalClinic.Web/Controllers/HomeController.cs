namespace DentalClinicSystem.Web.Controllers
{
   
    using ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Identity;

    public class HomeController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<IActionResult> AddUserToRole()
        //{
        //    var roleName = "Administrator";
        //    var roleExist = await roleManager.RoleExistsAsync(roleName);

        //    if (roleExist)
        //    {
        //        var user = await userManager.GetUserAsync(User);
        //        var result = await userManager.AddToRoleAsync(user, roleName);

        //        if (result.Succeeded)
        //        {
                    
        //        }
        //    }
        //}
    }
}