using System;
using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.BankAccount;
using GACKO.Shared.Models.BankAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using GACKO.Shared.Enums;
using GACKO.Shared.Exceptions;

namespace GACKO.Areas.BankAccount.Controllers
{
    [Area("BankAccount")]
    public class BankAccountController : GackoBaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(UserManager<DaoUser> userManager, 
            IBankAccountService bankAccountService,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _bankAccountService = bankAccountService;
            _userManager = userManager;
        }

        /// <summary>
        /// Bank Account Main Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Index()
        {
            var viewModel = new BankAccountListViewModel();
            try
            {
                viewModel.BankAccounts = await _bankAccountService.GetAll();
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }

            return View("Index", viewModel);
        }

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create(BankAccountForm bankAccount)
        {
            var viewModel = new BankAccountListViewModel();
            try
            {
                await _bankAccountService.Create(bankAccount);
                viewModel.BankAccounts = await _bankAccountService.GetAll();
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Update Bank Account
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(BankAccountForm bankAccount)
        {
            var viewModel = new BankAccountListViewModel();
            try
            {
                await _bankAccountService.Update(bankAccount);
                viewModel.BankAccounts = await _bankAccountService.GetAll();
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Delete Bank Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = new BankAccountListViewModel();
            try
            {
                await _bankAccountService.Delete(id);
                viewModel.BankAccounts = await _bankAccountService.GetAll();
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }
    }
}