using System.Net;
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
    public class ExpenseController : GackoBaseController
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService,
            UserManager<DaoUser> userManager,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _expenseService = expenseService;
        }

        /// <summary>
        /// Create Virtual Account's Expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create(ExpenseForm expense)
        {
            expense.ExpenseCategoryId = 10000;
            await _expenseService.Create(expense);
            var viewModel = new ExpenseListViewViewModel()
            {
                VirtualAccountId = expense.VirtualAccountId,
                Expenses = await _expenseService.GetAll(expense.VirtualAccountId)
            };
            return PartialView("_ExpenseList", viewModel);
        }

        /// <summary>
        /// Update Virtual Account's Expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(ExpenseForm expense)
        {
            await _expenseService.Update(expense);
            var viewModel = new ExpenseListViewViewModel()
            {
                VirtualAccountId = expense.VirtualAccountId,
                Expenses = await _expenseService.GetAll(expense.VirtualAccountId)
            };
            return PartialView("_ExpenseList", viewModel);
        }

        /// <summary>
        /// Delete Virtual Account's Expense
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expenseService.Get(id);
            await _expenseService.Delete(id);
            var viewModel = new ExpenseListViewViewModel()
            {
                VirtualAccountId = expense.VirtualAccountId,
                Expenses = await _expenseService.GetAll(expense.VirtualAccountId)
            };
            return PartialView("_ExpenseList", viewModel);
        }
    }
}