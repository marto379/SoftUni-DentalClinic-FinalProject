using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class DentistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
