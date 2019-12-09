using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.BankAccount;
using GACKO.Shared.Models.BankAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GACKO.Areas.BankAccount.Controllers
{
    [Area("BankAccount")]
    public class BankAccountController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(UserManager<DaoUser> userManager, IBankAccountService bankAccountService) : base(userManager)
        {
            _userManager = userManager;
            _bankAccountService = bankAccountService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bankAccs = await _bankAccountService.GetAll();

        [HttpPost]
        public async Task<IActionResult> Create(BankAccountForm bankAccount)
        {
            await _bankAccountService.Create(bankAccount);
            return View("Index", await _bankAccountService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Update(BankAccountForm bankAccount)
        {
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