using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.BankAccount;
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
        private readonly UserManager<DaoUser> _userManager;
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(UserManager<DaoUser> userManager, IBankAccountService bankAccountService)
        {
            _userManager = userManager;
            _bankAccountService = bankAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var bankAccs = await _bankAccountService.GetAll();

            bankAccs.Add(new BankAccountModel()
            {
                Iban = "23 2222 2222 2222 2222 2222 2222",
                Balance = 2137.00,
            });

            bankAccs.Add(new BankAccountModel()
            {
                Iban = "12 1111 1111 1111 1111 1111 2222",
                Balance = 1517.00,
            });

            return View("Index", bankAccs);
        }
    }
}
