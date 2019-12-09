using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.Expense;
using GACKO.Services.SalesDocument;
using GACKO.Services.VirtualAccount;
using GACKO.Shared.Models.SalesDocument;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class SalesDocumentController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly ISalesDocumentService _salesDocumentService;
        private readonly IExpenseService _expenseService;
        private readonly IVirtualAccountService _virtualAccountService;

        public SalesDocumentController(UserManager<DaoUser> userManager,
            ISalesDocumentService salesDocumentService,
            IExpenseService expenseService,
            IVirtualAccountService virtualAccountService,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _salesDocumentService = salesDocumentService;
            _expenseService = expenseService;
            _virtualAccountService = virtualAccountService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile fileForm, [FromForm] int expenseId)
        {
            var expense = await _expenseService.Get(expenseId);
            if (fileForm.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileForm.CopyTo(ms);
                    var fileRawData = ms.ToArray();
                    var salesDocument = new SalesDocumentForm()
                    {
                        ExpenseId = expenseId,
                        Name = fileForm.Name,
                        FileRawData = fileRawData
                    };
                    await _salesDocumentService.Create(salesDocument);
                }
            }

            var virtualAcc = await _virtualAccountService.Get(expense.VirtualAccountId);

            return View("Index", new VirtualAccountViewModel()
            {
                SelectedVirtualAccount = virtualAcc,
                VirtualAccounts = await _virtualAccountService.GetAll(virtualAcc.BankAccountId)
            });
        }
    }
}