using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.VirtualAccount;
using GACKO.Shared.Models.Expense;
using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GACKO.Shared.Models.Subscription;
using GACKO.Services.BankAccount;
using GACKO.Services.Subscription;
using GACKO.Services.Expense;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class VirtualAccountController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IVirtualAccountService _virtualAccountService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IExpenseService _expenseService;
        public static int _bankAccountId;

        public VirtualAccountController(UserManager<DaoUser> userManager, 
            IVirtualAccountService virtualAccountService, 
            ISubscriptionService subscriptionService, 
            IExpenseService expenseService, 
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _virtualAccountService = virtualAccountService;
            _subscriptionService = subscriptionService;
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int bankAccountId)
        {
            _bankAccountId = bankAccountId;

            var virtualAccs = await _virtualAccountService.GetAll(bankAccountId);
            var viewModel = new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = virtualAccs.FirstOrDefault(),
                VirtualAccounts = virtualAccs
            };
            if (viewModel.SelectedVirtualAccount == null )
            {
                var bankAccountViewModel = new VirtualAccountForm()
                {
                    BankAccountId = bankAccountId
                };
                return View("Create", bankAccountViewModel);
            }

            viewModel.SelectedVirtualAccount.Expenses = await _expenseService.GetAll(viewModel.SelectedVirtualAccount.Id);
            viewModel.SelectedVirtualAccount.Subscriptions = await _subscriptionService.GetAll(viewModel.SelectedVirtualAccount.Id);
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Create(int bankAccountId)
        {
            var bankAccountViewModel = new VirtualAccountForm()
            {
                BankAccountId = bankAccountId
            };

            return View("Create", bankAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VirtualAccountForm virtualAccount)
        {
             await _virtualAccountService.Create(virtualAccount);

            var viewModel = new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = _virtualAccountService.GetAll(virtualAccount.BankAccountId).Result.FirstOrDefault(),
                VirtualAccounts = _virtualAccountService.GetAll(virtualAccount.BankAccountId).Result
            };
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult ChangeVirtualAccActive(int bankAccId, int virtualAccId)
        {
            var viewModel = new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = _virtualAccountService.Get(virtualAccId).Result,
                VirtualAccounts = _virtualAccountService.GetAll(bankAccId).Result
            };

            return View("Index", viewModel);
        }
    }
}