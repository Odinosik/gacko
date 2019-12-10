using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GACKO.Controllers;
using GACKO.Services.Expense;
using GACKO.Shared.Models.Expense;
using Microsoft.AspNetCore.Mvc;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("Expense")]
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Index(int virtualAccountId)
        {
            return View("Index", await _expenseService.GetAll(virtualAccountId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseForm expense, int virtualAccountId)
        {
            expense.VirtualAccountId = virtualAccountId;
            await _expenseService.Create(expense);
            return View("Index", await _expenseService.GetAll(virtualAccountId));
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