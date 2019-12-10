using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.Expense;
using GACKO.Shared.Models.Expense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService,
            UserManager<DaoUser> userManager,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Index(int virtualAccountId)
        {
            return View("Index", await _expenseService.GetAll(virtualAccountId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseForm expense)
        {
            expense.ExpenseCategoryId = 10000;
            await _expenseService.Create(expense);
            var viewModel = new ExpenseListViewModel()
            {
                VirtualAccountId = expense.VirtualAccountId,
                Expenses = await _expenseService.GetAll(expense.VirtualAccountId)
            };
            return PartialView("_ExpenseList", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseForm expense, int virtualAccountId)
        {
            expense.VirtualAccountId = virtualAccountId;
            await _expenseService.Update(expense);
            return View("Index", await _expenseService.GetAll(virtualAccountId));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int virtualAccountId)
        {
            await _expenseService.Delete(id);
            return View("Index", await _expenseService.GetAll(virtualAccountId));
        }
    }
}