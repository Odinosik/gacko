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
        public IActionResult Index(int bankAccountId)
        {
            _bankAccountId = bankAccountId;
            /*
            var virtualAccs = new Dictionary<int, VirtualAccountModel>();
            
            virtualAccs.Add(0, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 0,
                        Amount = 15.0,
                        Name = "Disney"
                    },
                    new SubscriptionModel()
                    {
                        Id = 1,
                        Amount = 50.0,
                        Name = "CDA.PL"
                    }
                }
            });

            virtualAccs.Add(1, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 2,
                        Amount = 15.0,
                        Name = "Polsat"
                    },
                    new SubscriptionModel()
                    {
                        Id = 3,
                        Amount = 50.0,
                        Name = "Cartoon Network"
                    }
                }
            });

            virtualAccs.Add(2, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 4,
                        Amount = 15.0,
                        Name = "Netflix"
                    },
                    new SubscriptionModel()
                    {
                        Id = 5,
                        Amount = 50.0,
                        Name = "HBO"
                    }
                }
            });
            */

            var viewModel = new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = _virtualAccountService.GetAll(bankAccountId).Result.FirstOrDefault(),
                VirtualAccounts = _virtualAccountService.GetAll(bankAccountId).Result
            };
            if (viewModel.SelectedVirtualAccount == null )
            {
                var bankAccountViewModel = new VirtualAccountForm()
                {
                    BankAccountId = bankAccountId
                };
                return View("Create", bankAccountViewModel);
            }
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

            /*
            var virtualAccs = new Dictionary<int, VirtualAccountModel>();
            virtualAccs.Add(0, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 0,
                        Amount = 15.0,
                        Name = "Disney"
                    },
                    new SubscriptionModel()
                    {
                        Id = 1,
                        Amount = 50.0,
                        Name = "CDA.PL"
                    }
                }
            });

            virtualAccs.Add(1, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 2,
                        Amount = 15.0,
                        Name = "Polsat"
                    },
                    new SubscriptionModel()
                    {
                        Id = 3,
                        Amount = 50.0,
                        Name = "Cartoon Network"
                    }
                }
            });

            virtualAccs.Add(2, new VirtualAccountModel()
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
                },
                Subscriptions = new List<SubscriptionModel>()
                {
                    new SubscriptionModel()
                    {
                        Id = 4,
                        Amount = 15.0,
                        Name = "Netflix"
                    },
                    new SubscriptionModel()
                    {
                        Id = 5,
                        Amount = 50.0,
                        Name = "HBO"
                    }
                }
            });
            */
            var viewModel = new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = _virtualAccountService.Get(virtualAccId).Result,
                VirtualAccounts = _virtualAccountService.GetAll(bankAccId).Result
            };

            return View("Index", viewModel);
        }
    }
}