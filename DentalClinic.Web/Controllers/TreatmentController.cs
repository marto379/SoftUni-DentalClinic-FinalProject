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

        public IActionResult Prosthodontic()
        {
            return View();
        }

        public IActionResult Orthodontics()
        {
            return View();
        }

        public IActionResult Cleaning()
        {
            return View();
        }

        public IActionResult Caries()
        {
            return View();
        }
    }
}
