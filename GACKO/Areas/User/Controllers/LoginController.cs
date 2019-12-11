using System;
using AutoMapper;
using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using GACKO.Services.User;

namespace GACKO.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : GackoBaseController
    {
        private readonly SignInManager<DaoUser> _signInManager;
        private readonly IUserService _userService;

        public LoginController(UserManager<DaoUser> userManager,
            SignInManager<DaoUser> signInManager,
            IHttpContextAccessor contextAccessor,
            IUserService userService) : base(userManager, contextAccessor)
        {
            _signInManager = signInManager;
            _userService = userService;
        }


        /// <summary>
        /// Login Main Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Authorize(UserLoginForm userModel)
        {
            var viewModel = await _userService.LoginUser(userModel);
            if(viewModel.IsSuccess)
            {
                return RedirectToAction("Index", "BankAccount", new { area = "BankAccount" });
            }
            else
            {
                return View("Login", viewModel);
            }
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterForm userModel)
        {
            return View("Login", await _userService.RegisterUser(userModel));
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}