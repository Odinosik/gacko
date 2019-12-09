using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.ExpenseCategory;
using GACKO.Shared.Models.ExpenseCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Areas.ExpenseCategory.Controllers
{
    [Area("ExpenseCategory")]
    public class ExpenseCategoryController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryController(UserManager<DaoUser> userManager, IExpenseCategoryService expenseCategoryService)
        {
            _userManager = userManager;
            _expenseCategoryService = expenseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var expenseCategories = await _expenseCategoryService.GetAll();
            return View("Index", expenseCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseCategoryForm expenseCategory)
        {
            await _expenseCategoryService.Create(expenseCategory);
            return View("Index", await _expenseCategoryService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseCategoryForm expenseCategory)
        {
            await _expenseCategoryService.Update(expenseCategory);
            return View("Index", await _expenseCategoryService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseCategoryService.Delete(id);
            return View("Index", await _expenseCategoryService.GetAll());
        }
    }
}
