using System;
using System.Net;
using GACKO.DB.DaoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GACKO.Controllers
{
    public class HomeController : GackoBaseController
    {
        public HomeController(UserManager<DaoUser> userManager, IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
        }

        /// <summary>
        /// Main Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
