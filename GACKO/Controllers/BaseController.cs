using GACKO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GACKO.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class BaseController : Controller
    {      
        public BaseController()
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected RedirectToActionResult RedirectToHome(string action = "Index")
        {
            return RedirectToAction(action, "Home", new { area = "" });
        }
    }
}
