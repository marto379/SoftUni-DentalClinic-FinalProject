using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    [AllowAnonymous]
    public class TreatmentController : Controller
    {
        public IActionResult Root()
        {
            return View();
        }

        public IActionResult Extraction()
        {
            return View();
        }

        public IActionResult Whitening()
        {
            return View();
        }
    }
}
