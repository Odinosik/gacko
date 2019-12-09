using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.VirtualAccount;
using GACKO.Shared.Models.Expense;
using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class VirtualAccountController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IVirtualAccountService _virtualAccountService;

        public VirtualAccountController(UserManager<DaoUser> userManager, IVirtualAccountService virtualAccountService)
        {
            _userManager = userManager;
            _virtualAccountService = virtualAccountService;
        }

        [HttpGet]
        public IActionResult Index(int bankAccountId)
        {

            var virtualAccs =  _virtualAccountService.GetAll(bankAccountId).Result;

            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 0,
                Name = "Jedzenie",
                Balance = 200.00,
                Expenses = new List<ExpenseModel>() 
                {
                    new ExpenseModel()
                    {
                        Id = 0,
                        Amount = 100.0,
                        Name = "chleb",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Jedzenie"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 1,
                        Amount = 100.0,
                        Name = "zupa",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Jedzenie"
                        }
                    }
                }
            });

            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 1,
                Name = "Meble",
                Balance = 1000.00,
                Expenses = new List<ExpenseModel>()
                {
                    new ExpenseModel()
                    {
                        Id = 2,
                        Amount = 100.0,
                        Name = "krzeslo",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Meble"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 3,
                        Amount = 100.0,
                        Name = "fotel",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Meble"
                        }
                    }
                }
            });

            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 2,
                Name = "Podatki",
                Balance = 20000.00,
                Expenses = new List<ExpenseModel>()
                {
                    new ExpenseModel()
                    {
                        Id = 4,
                        Amount = 100.0,
                        Name = "PIT",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Podatki"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 5,
                        Amount = 100.0,
                        Name = "VAT",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Podatki"
                        }
                    }
                }
            });
            return View("Index", virtualAccs);
        }

        [HttpGet]
        public IActionResult ChangeVirtualAccActive(int bankAccId, int virtualAccId)
        {
            //var virtualAccs = _virtualAccountService.GetAll(bankAccId);
            var virtualAccs = new List<VirtualAccountModel>();
            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 0,
                Name = "Jedzenie",
                Balance = 200.00,
                Expenses = new List<ExpenseModel>()
                {
                    new ExpenseModel()
                    {
                        Id = 0,
                        Amount = 100.0,
                        Name = "chleb",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Jedzenie"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 1,
                        Amount = 100.0,
                        Name = "zupa",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Jedzenie"
                        }
                    }
                }
            });

            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 1,
                Name = "Meble",
                Balance = 1000.00,
                Expenses = new List<ExpenseModel>()
                {
                    new ExpenseModel()
                    {
                        Id = 2,
                        Amount = 100.0,
                        Name = "krzeslo",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Meble"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 3,
                        Amount = 100.0,
                        Name = "fotel",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Meble"
                        }
                    }
                }
            });

            virtualAccs.Add(new VirtualAccountModel()
            {
                Id = 2,
                Name = "Podatki",
                Balance = 20000.00,
                Expenses = new List<ExpenseModel>()
                {
                    new ExpenseModel()
                    {
                        Id = 4,
                        Amount = 100.0,
                        Name = "PIT",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Podatki"
                        }
                    },
                    new ExpenseModel()
                    {
                        Id = 5,
                        Amount = 100.0,
                        Name = "VAT",
                        ExpenseCategory = new ExpenseCategoryModel()
                        {
                            Name = "Podatki"
                        }
                    }
                }
            });
            return View("Index", virtualAccs);
        }
    }
}