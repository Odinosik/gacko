using GACKO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GACKO.Controllers
{
    [GackoExceptionFilter]
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController(UserManager<DaoUser> userManager, IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor.HttpContext.User != null)
            {
                var user = userManager.GetUserAsync(contextAccessor.HttpContext.User).Result;
                if (user != null)
                {
                    UserContext.UserId = user.Id;
                }
            }
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
