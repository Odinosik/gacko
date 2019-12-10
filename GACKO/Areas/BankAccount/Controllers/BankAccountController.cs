using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.BankAccount;
using GACKO.Shared.Models.BankAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GACKO.Areas.BankAccount.Controllers
{
    [Area("BankAccount")]
    public class BankAccountController : BaseController
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
            return View("Index", await _bankAccountService.GetAll());
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
            await _bankAccountService.Create(bankAccount);
            return View("Index", await _bankAccountService.GetAll());
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
            await _bankAccountService.Update(bankAccount);
            return View("Index", await _bankAccountService.GetAll());
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
            await _bankAccountService.Delete(id);
            return View("Index", await _bankAccountService.GetAll());
        }
    }
}