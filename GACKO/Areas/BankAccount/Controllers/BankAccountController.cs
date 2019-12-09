using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.BankAccount;
using GACKO.Shared;
using GACKO.Shared.Models.BankAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GACKO.Areas.BankAccount.Controllers
{
    [Area("BankAccount")]
    public class BankAccountController : BaseController
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(UserManager<DaoUser> userManager, IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bankAccs = await _bankAccountService.GetAll();
            return View("Index", bankAccs);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBankAccount(BankAccountForm bankAcc)
        {
            await _bankAccountService.Create(bankAcc);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBankAccount(BankAccountForm bankAcc)
        {
            await _bankAccountService.Update(bankAcc);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeActivate(BankAccountForm bankAcc)
        {
            await _bankAccountService.Update(bankAcc);
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(BankAccountForm bankAccount)
        {
            bankAccount.UserId = UserContext.UserId;
            await _bankAccountService.Create(bankAccount);
            return View("Index", await _bankAccountService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Update(BankAccountForm bankAccount)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(User);
            bankAccount.UserId = user.Id;
            await _bankAccountService.Update(bankAccount);
            return View("Index", await _bankAccountService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _bankAccountService.Delete(id);
            return View("Index", await _bankAccountService.GetAll());
        }
    }
}