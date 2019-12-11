using System;
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
using System.Net;
using GACKO.Shared.Models.Subscription;
using GACKO.Services.BankAccount;
using GACKO.Services.Subscription;
using GACKO.Services.Expense;
using System.Threading.Tasks;
using GACKO.Shared.Models.BankAccount;
using Microsoft.AspNetCore.Http;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class VirtualAccountController : GackoBaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IVirtualAccountService _virtualAccountService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IExpenseService _expenseService;

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

        /// <summary>
        /// Bank Account's Virtual Account Main Page
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Index(int bankAccountId)
        {
            var viewModel = new VirtualAccountViewModel() { VirtualAccounts = new List<VirtualAccountModel>() };
            try
            {
                var virtualAccs = await _virtualAccountService.GetAll(bankAccountId);
                var virtualAcc = virtualAccs.FirstOrDefault();
                if (virtualAcc == null)
                {
                    var bankAccountViewModel = new VirtualAccountForm()
                    {
                        BankAccountId = bankAccountId
                    };
                    return View("Create", bankAccountViewModel);
                }
                viewModel.SelectedVirtualAccount = await _virtualAccountService.Get(virtualAcc.Id);
                viewModel.VirtualAccounts = virtualAccs;
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }

            viewModel.SelectedVirtualAccount.Expenses = await _expenseService.GetAll(viewModel.SelectedVirtualAccount.Id);
            viewModel.expSum = viewModel.SelectedVirtualAccount.Expenses != null ? viewModel.SelectedVirtualAccount.Expenses.Sum(_ => _.Amount) : (0.00);
            viewModel.SelectedVirtualAccount.Subscriptions = await _subscriptionService.GetAll(viewModel.SelectedVirtualAccount.Id);
            viewModel.subSum = viewModel.SelectedVirtualAccount.Subscriptions != null ? viewModel.SelectedVirtualAccount.Subscriptions.Sum(_ => _.Amount) : (0.00);

            return View("Index", viewModel);
        }

        /// <summary>
        /// Create firt Virtual Account in Bank Account
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Create(int bankAccountId)
        {
            var bankAccountViewModel = new VirtualAccountForm()
            {
                BankAccountId = bankAccountId
            };

            return View("Create", bankAccountViewModel);
        }

        /// <summary>
        /// Create new Virtual Account
        /// </summary>
        /// <param name="virtualAccount"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create(VirtualAccountForm virtualAccount)
        {
            var viewModel = new VirtualAccountViewModel() { VirtualAccounts = new List<VirtualAccountModel>() };
            try
            {
                await _virtualAccountService.Create(virtualAccount);
                var virtualAccs = await _virtualAccountService.GetAll(virtualAccount.BankAccountId);
                var virtualAcc = virtualAccs.FirstOrDefault();
                if (virtualAcc == null)
                {
                    return RedirectToAction("Index", "BankAccount", new { area = "BankAccount" });
                }
                viewModel.SelectedVirtualAccount = await _virtualAccountService.Get(virtualAcc.Id);
                viewModel.VirtualAccounts = virtualAccs;
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Change active Virtual Account
        /// </summary>
        /// <param name="bankAccId"></param>
        /// <param name="virtualAccId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ChangeVirtualAccActive(int bankAccId, int virtualAccId)
        {
            var viewModel = new VirtualAccountViewModel() { VirtualAccounts = new List<VirtualAccountModel>() };
            try
            {
                viewModel.SelectedVirtualAccount = await _virtualAccountService.Get(virtualAccId);
                viewModel.VirtualAccounts = await _virtualAccountService.GetAll(bankAccId);
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }
        /// <summary>
        /// Update Virtual Account
        /// </summary>
        /// <param name="bankAccId"></param>
        /// <param name="virtualAccount"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(int bankAccId, VirtualAccountForm virtualAccount)
        {
            var viewModel = new VirtualAccountViewModel() { VirtualAccounts = new List<VirtualAccountModel>() };
            try
            {
                await _virtualAccountService.Update(virtualAccount);
                if (virtualAccount.Id != null)
                {
                    int virtualAccountId = (int) virtualAccount.Id;
                    viewModel.SelectedVirtualAccount = await _virtualAccountService.Get(virtualAccountId);
                }
                viewModel.VirtualAccounts = await _virtualAccountService.GetAll(bankAccId);
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return View("Index", viewModel);
        }
    }
}