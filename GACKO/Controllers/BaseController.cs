using GACKO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using Microsoft.AspNetCore.Identity;

namespace GACKO.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController(UserManager<DaoUser> userManager)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = HttpContext.User;
            var user = userManager.GetUserAsync(User).Result;
            UserContext.UserId = user.Id;
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
