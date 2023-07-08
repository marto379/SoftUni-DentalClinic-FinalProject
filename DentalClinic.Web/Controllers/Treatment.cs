using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    [AllowAnonymous]
    public class Treatment : Controller
    {
        public IActionResult Root()
        {
            return View();
        }
    }
}
