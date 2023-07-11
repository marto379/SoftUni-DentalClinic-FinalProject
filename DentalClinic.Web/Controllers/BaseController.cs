using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalClinicSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        //public string GetUserId()
        //{
        //    return User.FindFirstValue(ClaimTypes.NameIdentifier);
        //}

    }
}
